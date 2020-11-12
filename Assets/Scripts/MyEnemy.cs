using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _spawner;
    public void Hurt(int damage)
    {
        print("Ouch: " + damage);

        _health -= damage; ;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
        transform.position = _spawner.transform.position;
        gameObject.SetActive(true);
    }
    
}
