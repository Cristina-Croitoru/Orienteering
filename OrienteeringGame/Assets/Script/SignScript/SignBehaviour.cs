using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SignBehaviour : MonoBehaviour
{
    [Header("References")]
    public SignInitialize si; //Preluarea datelor din SignInitialize

    [Header("Text Animation")]
    public TextMeshProUGUI TextDisplay;
    public float delayBetweenCharacters = 0.01f;

    [Header("Interact")]
    public GameObject FPV; //First Player View Camera Obj
    public KeyCode Interact = KeyCode.F; //cand apasam F keycode Interact
    public LayerMask Sign;//Layer Sign
    public RaycastHit hit; //Raycast

    [Header("Text Var")]
    private string text; //Text preluat din SignInitialize
    private string currentText = ""; //Text Prelucrat

    [Header("EndGame Box Collider")]
    public GameObject EndGameBoxCollider; 
    public GameObject YellowUIPoint;    //End game obj apar la final

    private void Update()
    {
        //Checking for players in a sfera with it center in the middle of the transform
        // center of (obj , radius , layer to scan)
        si.isClose = Physics.CheckSphere(si.Obj.transform.position, 5, si.smthsmthplayer);
        si.isCloseToInteract = Physics.CheckSphere(si.Obj.transform.position, 3, si.smthsmthplayer);

        //if player is close to sign
        if ((si.isClose && !si.isCloseToInteract) & si.first)
        {
            //once time write
            si.first = false;
            si.second = true;
            text = si.TextA;
            StartCoroutine(AnimatedText());
        }
        //if player is close enough to sign to interact
        else if ((si.check && si.isCloseToInteract && si.isClose) & si.second)
        {
            //once time write
            si.second = false;
            si.first = true;
            text = si.TextC;
            StartCoroutine(AnimatedText());
        }
        //if player has interacted with the sign and it still close enough
        else if ((si.isClose && si.isCloseToInteract) & si.second)
        {
            //once time write
            si.second = false;
            si.first = true;
            text = si.TextB;
            StartCoroutine(AnimatedText());
        }
        //if player is far from sign
        else if (!si.isClose && !si.isCloseToInteract)
        {
            //once time write
            si.first = true;
            si.second = false;
        }
        CheckAllInstances();
    }

    private void FixedUpdate()
    {
        Vector3 direction = FPV.transform.forward + new Vector3(0, 0, 0);
        if (si.isCloseToInteract)
        {
           
            if (Physics.Raycast(FPV.transform.position, direction, out hit, 3f, Sign))
            {

                if (Input.GetKeyDown(Interact) && !si.check)
                {
                    hit.collider.GetComponent<SignBehaviour>().si.check = true;
                    si.second = true;
                }
            }
        }
    }

    private void CheckAllInstances()
    {
        bool allNotClose = true;
        bool allChecked = false;
        foreach (var instance in SignInitialize.AllInstances)
        {
            if (instance.isClose || instance.isCloseToInteract)
            {
                allNotClose = false;
                break;
            }
            Debug.Log(instance.check && (instance.isClose || instance.isCloseToInteract));
            if (instance.check && (instance.isClose || instance.isCloseToInteract))
            {
                Debug.Log("Check False");
                allChecked = true;
                break;
            }
        }
        Debug.Log(allChecked);

        if (allNotClose)
        {
            PerformActionWhenAllNotClose();
        }
        if (allChecked)
        {
            EndGameEnable();
        }
    }

    private void PerformActionWhenAllNotClose()
    {
            currentText = "";
            TextDisplay.SetText(currentText);
    }


    private void EndGameEnable()
    {
        Debug.Log("Yaya");
        EndGameBoxCollider.gameObject.SetActive(true);
        YellowUIPoint.gameObject.SetActive(true);
    }



    //Animatia de la text
    IEnumerator AnimatedText()
    {
        currentText = si.PersonTalk;
        TextDisplay.SetText(currentText);
        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i <= text.Length; i++)
        {
            currentText = si.PersonTalk + text.Substring(0, i);
            TextDisplay.SetText(currentText);
            yield return new WaitForSeconds(delayBetweenCharacters);
        }
    }
}