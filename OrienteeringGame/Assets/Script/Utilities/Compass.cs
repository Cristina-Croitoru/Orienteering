using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform player;    // variable to reference the player's Transform component, this will be assigned in the Unity Editor
    Vector3 dir;                // store the direction vector


    void Update()
    {
        dir.z = player.eulerAngles.y;   // ulerAngles is a property of Transform that returns the rotation
                                        // as a Vector3 representing the rotation in degrees
                                        // in my case axis horizontal y


        transform.localEulerAngles = dir;   // will rotate the compass to match the direction the player is facing
    }
}
