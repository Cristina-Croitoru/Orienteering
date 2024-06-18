using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour    // MainMenu inherits from MonoBehaviour, a base class required for all Unity script
{
    public void PlayGame ()              // PlayButton
    {
        SceneManager.LoadSceneAsync(1);  // loads the scene with the index 1 
    }

    public void QuitGame()               // QuitButton
    {
        Debug.Log("Quit");               // logs the message "Quit" to the Unity Console
        Application.Quit();
    }
}
