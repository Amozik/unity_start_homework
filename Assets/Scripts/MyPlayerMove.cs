using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMove : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed = 3; 
    [SerializeField] private float _turnSpeed = .2f;
    [SerializeField] private GameObject _mine;
    [SerializeField] private Transform _mineSpawnPlace;

    private Vector3 _startPos = Vector3.zero;
    private int startHealth = 0;

    private Vector3 _direction;
    private List<string> keys;
    private Animator _animator;

    private void Awake()
    {
        keys = new List<string>();
        _startPos = transform.position;
        startHealth = _health;
        _animator = GetComponent<Animator> ();
    }

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody clone = Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation).GetComponent<Rigidbody>();
            clone.AddForce(transform.forward * 200);
        }

        _animator.SetBool ("IsWalking", _direction != Vector3.zero);
    }

    private void FixedUpdate()
    {        
        if (_direction != Vector3.zero) 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction.normalized), _turnSpeed);

        var speed = _direction * _speed * Time.fixedDeltaTime;
        transform.Translate(speed, Space.World);
    }

    public void Heal(int health)
    {
        _health += health;
    }
    public void Hurt(int damage)
    {              
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        transform.position  = _startPos;
        _health = startHealth;
    }

    public void AddKey(string keyName)
    {
        keys.Add(keyName);        
    }

    public bool HasKey(string keyName)
    {
        Debug.Log(keyName);
        return keys.Contains(keyName);
    }

}
