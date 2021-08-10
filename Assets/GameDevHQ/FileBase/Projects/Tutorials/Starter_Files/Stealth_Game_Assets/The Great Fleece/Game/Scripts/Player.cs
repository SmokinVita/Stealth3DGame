using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    private NavMeshAgent _playerAgent;

    private Animator _anim;
    private Vector3 _hitLocation;

    void Start()
    {
        _playerAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
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
                _hitLocation = hit.point;

            }
        }

        if (transform.position.x == _hitLocation.x && transform.position.z == _hitLocation.z)
        {
            Debug.Log("Got to the pos!");
            _anim.SetBool("Walk", false);
        }
    }
}
