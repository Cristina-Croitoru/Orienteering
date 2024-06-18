using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class SignInitialize : MonoBehaviour
{
    public static List<SignInitialize> AllInstances = new List<SignInitialize>();


    [Header("References idk")]
    public GameObject Obj;
    public bool isClose;
    public bool isCloseToInteract;
    public LayerMask smthsmthplayer;
    public SignBehaviour ta;

    [Header("TextAnimation")]
    public string PersonTalk;
    public bool first = true;
    public bool second = true;

    [Header("IwasChecked")]
    public bool check = false;

    [Header("Is Close Text")]
    [TextArea(7, 7)]
    public string TextA;

    [Header("Close To Interact Text")]
    [TextArea(7, 7)]
    public string TextB;

    [Header("Checked Me Text")]
    [TextArea(7, 7)]
    public string TextC;

    private void OnEnable()
    {
        AllInstances.Add(this);
    }

    private void OnDisable()
    {
        AllInstances.Remove(this);
    }
}