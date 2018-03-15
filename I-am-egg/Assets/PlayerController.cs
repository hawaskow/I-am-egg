using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov; 
        Vector3 movVertical = transform.forward * zMov;
        Vector3 _velocity = (movHorizontal + movVertical).normalized * speed;

        motor.Move(_velocity);
        //Calculate rotation as 3D vector applies to player not camera
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;

        motor.Rotate(_rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 _cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensitivity;

        motor.RotateCamera(_cameraRotation);
    }

}
