using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementByFox : MonoBehaviour
{
    Rigidbody rb;
    public float jumpImpulseValue;
    public float jumpForce;
    bool canJump = true;
    Vector3 up = Vector3.up;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (canJump) { rb.AddForce(up * jumpImpulseValue, ForceMode.Impulse); canJump = false; }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(up * jumpForce * Time.deltaTime, ForceMode.Force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="DeadZone") { Destroy(gameObject); }
        if (other.tag == "Candle") 
        {
            CandleManager.instance.AddScore(5);
            other.gameObject.SetActive(false);
        }
    }
}
