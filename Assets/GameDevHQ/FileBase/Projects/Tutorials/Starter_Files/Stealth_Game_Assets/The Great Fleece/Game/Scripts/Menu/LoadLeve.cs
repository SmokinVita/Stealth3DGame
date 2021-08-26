using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLeve : MonoBehaviour
{

    [SerializeField]
    private Image _progressBar;

    void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }

    private IEnumerator LoadLevelAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main");

        while(!asyncLoad.isDone)
        {
            _progressBar.fillAmount = asyncLoad.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
