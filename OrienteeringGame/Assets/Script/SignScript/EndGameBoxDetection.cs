using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class EndGameBoxDetection : MonoBehaviour
{
    public float delayBetweenCharacters = 0.01f;
    private bool first = true;
    public TextMeshProUGUI TextDisplay;
    [TextArea(7, 7)]
    public string Text;
    public string PersonTalk;
    public bool Inside;

    private string currentText = "";

    private void Start()
    {
        TextDisplay.SetText("");
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == LayerMask.NameToLayer("Player")) & first)
        {
            Inside = true;
            first = false;
            StartCoroutine(WritingAnimation());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Inside = false;
        TextDisplay.SetText("");
    }

    IEnumerator WritingAnimation()
    {
        currentText = PersonTalk;
        TextDisplay.SetText(currentText);
        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i <= Text.Length; i++)
        {
            currentText = PersonTalk + Text.Substring(0, i);
            TextDisplay.SetText(currentText);
            yield return new WaitForSeconds(delayBetweenCharacters);
        }
    }

    public void Update()
    {
        float timer = Time.deltaTime;
    }
}