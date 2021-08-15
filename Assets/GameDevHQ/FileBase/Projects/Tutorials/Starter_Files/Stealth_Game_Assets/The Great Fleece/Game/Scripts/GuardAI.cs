using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{

    [SerializeField]
    private List<Transform> _waypoints;
    [SerializeField]
    private int _currentTargetIndex = 0;
    [SerializeField]
    private bool _coindTossed = false;
    private Vector3 _coinDistace;

    private bool _reverseWaypoints = false;
    private bool _targetReached = false;


    private NavMeshAgent _guardAgent;
    private Animator _anim;

    void Start()
    {
        _guardAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (_waypoints.Count > 0 && _waypoints[_currentTargetIndex] != null && _coindTossed == false)
        {

            _guardAgent.SetDestination(_waypoints[_currentTargetIndex].position);


            float distance = Vector3.Distance(transform.position, _waypoints[_currentTargetIndex].position);

            if (distance < 1 && (_currentTargetIndex == 0 || _currentTargetIndex == _waypoints.Count - 1))
            {
                _anim.SetBool("Walk", false);
            }
            else
            {
                _anim.SetBool("Walk", true);
            }

            if (distance < 1f && _targetReached == false)
            {
                _targetReached = true;
                StartCoroutine(WaitBeforeMovingRoutine());
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, _coinDistace);

            if(distance < 2.5f)
            {
                _anim.SetBool("Walk", false);
            }
        }
    }

    IEnumerator WaitBeforeMovingRoutine()
    {
        int randomYield = Random.Range(3, 5);


        if (_currentTargetIndex == 0)
        {
            yield return new WaitForSeconds(randomYield);

        }
        else if (_currentTargetIndex == _waypoints.Count - 1)
        {
            yield return new WaitForSeconds(randomYield);

        }

        if (_reverseWaypoints == false)
        {
            if (_currentTargetIndex == _waypoints.Count - 1)
            {
                _reverseWaypoints = true;
            }
            else
            {
                _currentTargetIndex++;
            }
        }
        else if (_reverseWaypoints == true)
        {
            if (_currentTargetIndex == 0)
            {
                _reverseWaypoints = false;
            }
            else
            {
                _currentTargetIndex--;
            }
        }

        _targetReached = false;
    }

    public void HeardCoinTossed(Vector3 coinPos)
    {
        _guardAgent.SetDestination(coinPos);
        _coindTossed = true;
        _anim.SetBool("Walk", true);
        _coinDistace = coinPos;
    }
}
