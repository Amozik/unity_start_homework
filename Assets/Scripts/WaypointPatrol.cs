using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    private bool _isPatrolling = true;
    private WaitForSeconds _waitTime = null;
    
    int m_CurrentWaypointIndex;

    void Start () {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update ()
    {
        if (_isPatrolling && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }

    private IEnumerator SetPatrolling(bool value)
    {
        _isPatrolling = value;
        yield return _waitTime;
    }
    public void StartPatrol()
    {
        if (_isPatrolling) return;

        _waitTime = new WaitForSeconds(5f);
        StartCoroutine(SetPatrolling(true));
    }
    
    public void StopPatrol()
    {
        if (!_isPatrolling) return;
        
        StopAllCoroutines();
        _waitTime = null;
        StartCoroutine(SetPatrolling(false));
    }
}
