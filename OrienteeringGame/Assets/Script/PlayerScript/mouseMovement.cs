using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMovement : MonoBehaviour
{


    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform CamHolder;

    float xRotation;
    float YRotation;

    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
       CamMovement();
    }

    public void CamMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;

        //control rotation around y axis (Look up and down)
        YRotation += mouseX;

        //control rotation around x axis (Look up and down)
        xRotation -= mouseY;

        //we clamp the rotation so we cant Over-rotate (like in real life)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //applying both rotations
        transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f);

        CamHolder.rotation = Quaternion.Euler(xRotation, YRotation, 0);
        orientation.rotation = Quaternion.Euler(0, YRotation, 0);
    }
}
