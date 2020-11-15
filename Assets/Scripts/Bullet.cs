using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed = 20f;
    private Vector3 _target = Vector3.zero;
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    public void Init(Vector3 target)
    {
        _target = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<MyPlayerMove>();
            player.Hurt(1);
            Destroy(gameObject);
        }
    }

}
