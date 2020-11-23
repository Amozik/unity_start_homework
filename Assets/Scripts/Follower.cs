using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    public Transform player;
    
    private bool _isFollowing = false;
    private NavMeshAgent _navMeshAgent;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_isFollowing)
        {
            _navMeshAgent.SetDestination(player.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerScript = collision.gameObject.GetComponent<MyPlayerMove>();
            playerScript.Hurt(playerScript.health);
            _isFollowing = false;
        }
    }

    public void SetFollowing(bool value)
    {
        _isFollowing = value;
    }
    
}
