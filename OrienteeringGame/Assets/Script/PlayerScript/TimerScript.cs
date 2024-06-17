using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    public float clock = 0;

    public void Update()
    {
        clock += Time.deltaTime;
        string displaystring = String.Format("{0:0.00}",clock);
        TextDisplay.SetText(displaystring + " sec");
    }
}
