using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    [SerializeField]
    private GameObject _coinPrefab;
    [SerializeField]
    private AudioClip _coinClip;
    private bool _hasThrownCoin = false;

    private NavMeshAgent _playerAgent;

    private Animator _anim;
    private Vector3 _hitLocation;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();

        _playerAgent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _playerAgent.SetDestination(hit.point);

                _anim.SetBool("Walk", true);
                _hitLocation = hit.point + new Vector3(0, 2f, 0);
            }
        }

        float distance = Vector3.Distance(transform.position, _hitLocation);

        if (distance < 1.5f)
        {
            _anim.SetBool("Walk", false);
        }

        if (Input.GetMouseButtonDown(1) && !_hasThrownCoin)
        {
            _anim.SetTrigger("Throw");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _hasThrownCoin = true;
                Instantiate(_coinPrefab, hit.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_coinClip, hit.point);
                SendAIToCoinPos(hit.point);
            }

        }
    }

    private void SendAIToCoinPos(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach (var guard in guards)
        {
            guard.GetComponent<GuardAI>().HeardCoinTossed(coinPos);
        }
    }
}
