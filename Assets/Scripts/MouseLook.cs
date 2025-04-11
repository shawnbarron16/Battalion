using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    public float xSensitivity = 500f;
    public float ySensitivity = 500f;

    public Transform playerBody;

    float xRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Capture the player mouse input, time.delta time is used to make sure the frame rate does not impact look speed
        float mouseX = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;

        //Rotate the player camera side to side
        playerBody.Rotate(Vector3.up * mouseX); 

        //Rotate the player camera up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
