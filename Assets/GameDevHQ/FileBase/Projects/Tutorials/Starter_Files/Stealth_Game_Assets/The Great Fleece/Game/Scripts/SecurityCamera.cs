using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{

    [SerializeField]
    private GameObject _cutScene;
    [SerializeField]
    private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            Renderer _render = GetComponent<Renderer>();
            Color color = new Color(.6f, .1f, .1f, .3f);
            _render.material.SetColor("_TintColor", color);
            _animator.enabled = false;
            StartCoroutine(DelayCutsceneRoutine());
            
        }
    }

    private IEnumerator DelayCutsceneRoutine()
    {
        yield return new WaitForSeconds(.5f);
        _cutScene.SetActive(true);
    }
}
