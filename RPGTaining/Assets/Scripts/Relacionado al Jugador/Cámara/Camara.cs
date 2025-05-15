using System.Security;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Camara : MonoBehaviour
{

    private float horizontalAxis;
    private float verticalAxis;

    private new Transform camera;
    public Vector2 sens = new Vector2(1f,1f);

    // Start is called before the first frame update
    void Start()
    {
        camera = transform.Find("Camara");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        horizontalAxis = Input.GetAxis("Mouse X");
        verticalAxis = Input.GetAxis("Mouse Y");

        if(horizontalAxis != 0){
            transform.Rotate(Vector3.up * horizontalAxis * sens.x);
        }

        if(verticalAxis != 0){
            //camera.Rotate(Vector3.left * verticalAxis * sens.y);
            float angle = (camera.localEulerAngles.x - verticalAxis * sens.y + 360) % 360;
            if(angle > 180) {angle -=360;}
            angle = Mathf.Clamp(angle, -90, 90);

            camera.localEulerAngles = Vector3.right * angle;
        }
    }
}