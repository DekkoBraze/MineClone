using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMovement : MonoBehaviour
{
    public float speed = 10;
    public float gravity = -9.8f;

    public Rigidbody body;
    public CharacterController charController;

    void Start()
    {
        PhysicsOff(body);
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }

    private void PhysicsOff(Rigidbody body)
    {
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }
}