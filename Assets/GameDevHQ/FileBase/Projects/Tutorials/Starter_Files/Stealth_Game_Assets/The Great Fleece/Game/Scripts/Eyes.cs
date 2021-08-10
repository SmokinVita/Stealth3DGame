using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{

    [SerializeField]
    private GameObject _gameOverCutScene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Got Caught");
            _gameOverCutScene.SetActive(true);
        }
    }

}
