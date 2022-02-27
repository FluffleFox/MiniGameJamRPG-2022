using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] 
    private float _sensitivity = 180.0f;
    private float _rotationX;
    private float _rotationY;

    public Transform playerBody;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;

        
        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
