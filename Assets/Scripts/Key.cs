using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private string _name = "key";


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<MyPlayerMove>()?.AddKey(_name);
            Destroy(gameObject);
        }
    }
}
