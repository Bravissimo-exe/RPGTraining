using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpHeight = 1.9f;
    [SerializeField] private float gravityScale = -20f;

    private Vector3 movementVelocity = Vector3.zero;
    private CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();

        // Alternativamente: runSpeed = walkSpeed * 2f;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        //Sacamos las entradas
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1f); //limita el vector a 1

        //Definimos la velocidad
        float speed = Input.GetButton("Sprint") ? runSpeed : walkSpeed;
        Vector3 moveDirection = transform.TransformDirection(new Vector3(input.x, 0f, input.y)) * speed; //Lo pasamos a un Vector3

        // Movimiento horizontal -> al movimiento final
        movementVelocity.x = moveDirection.x; 
        movementVelocity.z = moveDirection.z;

        // Comprobamos si el personaje está en el suelo
        if (characterController.isGrounded)
        {
            // movementVelocity.y = -2f; //si se pone el personaje empieza a bajar a salitos en pendientes
            if (Input.GetButtonDown("Jump")){
                movementVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale); //Fórmula para el salto -> Raíz(-2a * d)
            }
        }
        else{
            // Aplicar gravedad (si no está en el piso)
            movementVelocity.y += gravityScale * Time.deltaTime;
        }

        // Aplicar movimiento final
        characterController.Move(movementVelocity * Time.deltaTime);
    }
}
