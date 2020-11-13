using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenedDoor : MonoBehaviour
{
    [SerializeField] private string _keyName = "key";

    public GameObject[] walls;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<MyPlayerMove>();
            if (player && player.HasKey(_keyName))
            {                
                Destroy(gameObject);
                foreach (GameObject item in walls)
                {
                    Destroy(item);
                }
            }
        }
    }

}
