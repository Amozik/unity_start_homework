using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private GameObject _explosion = null;
    [SerializeField]private AudioClip _sfxExplosion;

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var exp = Instantiate(_explosion, transform.position, Quaternion.identity);
            var audioSrc = exp.AddComponent<AudioSource>();
            audioSrc.volume *= MainMenu.soundVolume;
            audioSrc.PlayOneShot(_sfxExplosion);
            
            Destroy(exp, exp.GetComponent<ParticleSystem>().main.duration);

            var enemy = collision.gameObject.GetComponent<MyEnemy>();
            enemy.Hurt(_damage);

            Destroy(gameObject);
        }
    }

}
