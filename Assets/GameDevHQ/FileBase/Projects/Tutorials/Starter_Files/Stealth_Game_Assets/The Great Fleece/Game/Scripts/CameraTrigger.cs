using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;
    [SerializeField]
    private Transform _newCameraPos;
    //Check for Trigger of Player
    //Update main camera to approrpirate angle

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger Activated!");
            if(_mainCamera != null)
            {
                _mainCamera.transform.position = _newCameraPos.position;
                _mainCamera.transform.rotation = _newCameraPos.rotation;
            }
        }
    }

}
