using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 20f;
    [SerializeField] private GameObject _bullet = null;
    [SerializeField] private float _bulletForce = 1000;    
    [SerializeField] private Transform _bulletSpawnPos = null;    
    [SerializeField] private float _bulletTimer = 1.5f;
    private float _timer = 0;

    private Animator _animator = null;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        Collider player = Array.Find(Physics.OverlapSphere(transform.position, 5), e => e.CompareTag("Player"));
        bool isVisible = false;

        if (player) {

            //Тут я попытался сделать, чтобы персонажа не отслеживали через стены
            //но, на мой взгляд, после добавления плавного вращения, стало работать не очень
            RaycastHit hit;
            if (Physics.Linecast(_bulletSpawnPos.position, player.transform.position, out hit))
            {
                if (hit.collider.CompareTag("Player")) {
                   isVisible = true;
                }
            }            
        }
        
        if (isVisible)
        {
            _animator.SetFloat("speed", 0);
            //transform.LookAt(player.transform);
            Vector3 targetDir = player.transform.position - transform.position;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, _turnSpeed * Time.deltaTime, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
            //transform.rotation = Quaternion.LookRotation(targetDir);

            _timer -= Time.deltaTime;
            if (_timer < 0 )
            {
                _timer = _bulletTimer;
                //Vector3 dir = player.transform.position - _bulletSpawnPos.position;
                var bulletScript = Instantiate(_bullet, _bulletSpawnPos.position, Quaternion.LookRotation(targetDir)).GetComponent<Bullet>();
                bulletScript.Init(player.transform.position);
            }
        } else
        {
            _animator.SetFloat("speed", 1);            
        }
        
    }
}
