using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Observer : MonoBehaviour
{
    public Transform player;
    public UnityEvent onVisible = null;
    public UnityEvent offVisible = null;

    bool m_IsPlayerInRange;

    void OnTriggerEnter (Collider other)
    {
        if (!m_IsPlayerInRange && other.CompareTag("Player"))
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        //if (!m_IsPlayerInRange) return;
        
        if (m_IsPlayerInRange && other.CompareTag("Player"))
        {
            m_IsPlayerInRange = false;
            
            offVisible?.Invoke();
        }
    }

    void Update ()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            Debug.DrawRay(transform.position, direction, Color.red);

            if (Physics.Raycast (ray, out raycastHit))
            {
                if (raycastHit.collider.CompareTag("Player"))
                {
                    onVisible?.Invoke();
                }
            }
        }
    }
}
