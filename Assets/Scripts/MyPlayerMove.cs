using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMove : MonoBehaviour
{
    public int health = 3;
    [SerializeField] private float _speed = 3; 
    [SerializeField] private float _turnSpeed = .2f;
    [SerializeField] private float _jumpForce = 200f;
    [SerializeField] private GameObject _mine;
    [SerializeField] private Transform _mineSpawnPlace;

    private Vector3 _startPos = Vector3.zero;
    private int startHealth = 0;

    private Vector3 _direction;
    private List<string> keys;
    private Animator _animator;
    private Rigidbody _rb;
    private bool _isGrounded;

    private void Awake()
    {
        keys = new List<string>();
        _startPos = transform.position;
        startHealth = health;
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameMenu.gameIsPaused) return;
        
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody clone = Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation).GetComponent<Rigidbody>();
            clone.AddForce(transform.forward * 200);
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpForce);
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
        this.health += health;
    }
    public void Hurt(int damage)
    {              
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        transform.position  = _startPos;
        health = startHealth;
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
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
 
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

}
