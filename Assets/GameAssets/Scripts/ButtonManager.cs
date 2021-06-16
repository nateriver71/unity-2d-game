using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        //SceneManager.LoadScene("");
    }

    public void ExitGame()
    {
        Debug.Log("Application Exitted");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit(0);
    }
}
