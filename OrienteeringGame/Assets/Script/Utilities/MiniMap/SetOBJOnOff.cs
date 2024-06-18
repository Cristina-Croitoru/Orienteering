using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetOBJOnOff : MonoBehaviour
{
    [Header("On/Off OBJ")]     // for better organization
    public bool onoff;         // bool variable that determines whether the UIPLayerOBJ GameObject should be active or not

    [Header("OBJ to On/OFF")]   // for better organization
    public GameObject UIPLayerOBJ;   // variable to reference the GameObject that will be toggled on or off

    private void Start()             // Start method is called before the first frame update,
                                     // when the script instance is being loaded!!!!!!!
    {
        UIPLayerOBJ.SetActive(onoff);   //
    }

}
