using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Mouse sensitivity

    public Transform playerBody; // A reference to the player body, where the camera will be rotating

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor at the centre of the screen
    }

    // Update is called once per frame
    void Update()
    {
        /*
            This section will get the x and y input of the mouse and multiply
            by mouse sensitivity and delta time. This will update independent
            of frame rate.
         
        */
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the rotation so it won't go over 180 degree view point

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX); // Rotate on the X axis
    }
}
