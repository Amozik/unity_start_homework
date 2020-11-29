using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenedDoor : MonoBehaviour
{
    [SerializeField] private string _keyName = "key";

    public GameObject[] walls;
    public Collision_Proxy closedTrigger;
    
    private Animator _animator;
    private bool _isOpen = false; 

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isOpen) return;
        
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<MyPlayerMove>();
            if (player && player.HasKey(_keyName))
            {                
                _isOpen = true;
                _animator.SetBool("isOpen", _isOpen);
                
                //Destroy(gameObject);
                ShowWalls(false);
            }
            
            closedTrigger.OnTriggerEnter_Action += ClosedTrigger_OnTriggerEnter;
        }
    }
    
    private void ClosedTrigger_OnTriggerEnter(Collider other)
    {
        if (!_isOpen) return;

        if (other.CompareTag("Player"))
        {
            //_isOpen = false;
            _animator.SetBool("isOpen", false);
        }
    }

    private void OnDoorClosed()
    {
        ShowWalls();
    }

    private void ShowWalls(bool value = true)
    {
        foreach (GameObject item in walls)
        {
            item.SetActive(value);
        }
    }

}
