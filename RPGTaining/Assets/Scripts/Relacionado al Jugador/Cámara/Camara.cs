using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Camara : MonoBehaviour
{
    private float horizontalAxis;
    private float verticalAxis;

    [SerializeField] private Transform camaraTransform;  // <- en lugar de usar Find
    public Vector2 sens = new Vector2(1f, 1f);

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        horizontalAxis = Input.GetAxis("Mouse X");
        verticalAxis = Input.GetAxis("Mouse Y");

        if (horizontalAxis != 0)
        {
            transform.Rotate(Vector3.up * horizontalAxis * sens.x);
        }

        if (verticalAxis != 0 && camaraTransform != null)
        {
            float angle = (camaraTransform.localEulerAngles.x - verticalAxis * sens.y + 360) % 360;
            if (angle > 180) { angle -= 360; }
            angle = Mathf.Clamp(angle, -90, 90);

            camaraTransform.localEulerAngles = Vector3.right * angle;
        }
    }
}
