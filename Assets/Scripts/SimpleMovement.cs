using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 12.0f;
    public CharacterController controller;

    private Vector3 velocity;
    public float gravityForce = -9.81f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * x + transform.forward * z;

        controller.Move(direction * (_speed * Time.deltaTime));

        velocity.y += gravityForce * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
