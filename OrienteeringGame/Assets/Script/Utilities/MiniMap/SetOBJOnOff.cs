using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetOBJOnOff : MonoBehaviour
{
    [Header("On/Off OBJ")]
    public bool onoff;

    [Header("OBJ to On/OFF")]
    public GameObject UIPLayerOBJ;

    private void Start()
    {
        UIPLayerOBJ.SetActive(onoff);
    }

}
