using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    public static float mouseSensitivity = 100f;
    
    public Transform playerBody;
   

    private float xRotation = 0f;
    // Update is called once per frame
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        playerBody.Rotate(Vector3.up * mouseX);
        
    }


   
}
