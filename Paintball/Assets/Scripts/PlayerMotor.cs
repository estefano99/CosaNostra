using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    // RESPAWN
    public Vector3 respawn;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    public Camera cam;

    private Rigidbody rb;

    private void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Obtener vector de movimiento
    public void Move (Vector3 _velocity)
    {
        velocity = _velocity;
    }

    // Obtener vector de movimiento
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    // Correr todas las interacciones fisicas
    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();

        //RESPAWN
        if(transform.position.y < -2)
        {
            respawn = new Vector3(0,10,0);
            transform.position = respawn;
        }
    }

    // Realizar movimiento basado en variable velocidad
    private void PerformMovement ()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    // Realizar rotacion
    void PerformRotation ()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }
}
