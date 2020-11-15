using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private float _rotateSpeed = 50f;

    private void Update()
    {
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<MyPlayerMove>()?.Heal(_health);
            Destroy(gameObject);
        }
    }
}
