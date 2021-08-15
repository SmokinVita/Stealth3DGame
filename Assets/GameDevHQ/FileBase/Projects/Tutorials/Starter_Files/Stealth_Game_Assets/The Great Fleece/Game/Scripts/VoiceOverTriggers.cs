using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTriggers : MonoBehaviour
{
    [SerializeField]
    private Transform mainCam;
    [SerializeField]
    private AudioClip _voiceOver;


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(_voiceOver, mainCam.position);
            Debug.Log("Voice Over Trigger called!");
        }
    }
}
