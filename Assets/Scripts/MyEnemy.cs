using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _spawner;
    private int startHealth = 0;
    private Rigidbody _rb;

    private void Awake()
    {
        startHealth = _health;
        _rb = GetComponent<Rigidbody>();
    }

    public void Hurt(int damage)
    {
        //print("Ouch: " + damage);        
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        } else
        {            
            //не получилось сделать плавное откидование врага от взрыва
            //transform.Translate(-damage * transform.forward, Space.World); 
            _rb.AddForce(-damage * 100 * transform.forward);
        }
    }

    private void Die()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
        startHealth++;
        _health = startHealth;

        transform.position = _spawner.transform.position;
        gameObject.SetActive(true);
    }
    
}
