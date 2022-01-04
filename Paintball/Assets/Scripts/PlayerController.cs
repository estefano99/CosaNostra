using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float lookSensitivity = 3f;

    private PlayerMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calcular la velocidad de movimiento como vector 3D
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        // Vector final de movimiento
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        // Aplicar movimiento
        motor.Move(velocity);

        // Calcular rotacion como vector 3D horizontal
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        // Aplicar rotacion
        motor.Rotate(_rotation);

        // Calcular rotacion como vector 3D vertical
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

        // Aplicar rotacion de camara
        motor.RotateCamera(_cameraRotation);
    }
}
