using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

    public void QuitGame()
    {
        if(Application.isEditor)
        {
            Debug.Log("You quit The Game!");
        }
        else
        {
            Application.Quit();
        }
    }
}
