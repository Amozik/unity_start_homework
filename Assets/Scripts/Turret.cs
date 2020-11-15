using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 20f;
    [SerializeField] GameObject bullet = null;
    [SerializeField] Transform bulletSpawnPos = null;    
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

            //Тут я попытался сдлать, чтобы персонажа не отслеживали через стены
            //но, на мой взгляд, после добавления плавного вращения, стало работать не очень
            RaycastHit hit;
            if (Physics.Linecast(transform.position, player.transform.position, out hit))
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

            _timer += Time.deltaTime;
            if (_timer > _bulletTimer)
            {
                _timer = 0;
                Vector3 dir = player.transform.position - bulletSpawnPos.position;
                var bulletScript = Instantiate(bullet, bulletSpawnPos.position, Quaternion.LookRotation(targetDir)).GetComponent<Bullet>();
                bulletScript.Init(player.transform.position);
            }
        } else
        {
            _animator.SetFloat("speed", 1);            
        }
        
    }
}
