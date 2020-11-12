using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 3; 
    [SerializeField] private float _turnSpeed = .2f;
    [SerializeField] private GameObject _mine;
    [SerializeField] private Transform _mineSpawnPlace;

    private Vector3 _direction;

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody clone = Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation).GetComponent<Rigidbody>();
            clone.AddForce(transform.forward * 200);
        }

    }

    private void FixedUpdate()
    {        
        if (_direction != Vector3.zero) 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction.normalized), _turnSpeed);

        var speed = _direction * _speed * Time.fixedDeltaTime;
        transform.Translate(speed, Space.World);
    }

}
