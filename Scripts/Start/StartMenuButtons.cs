using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour
{
    public bool isStart, isQuit;

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("Esc pressed.");
            Application.Quit();
        }
    }

    public void sceneChanger()
    {
        if (isStart)
        {
            SceneManager.LoadScene("StartStoryScene");
        }else if (isQuit)
        {
            Application.Quit();
        }
    }
}
