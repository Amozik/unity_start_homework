using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _player = null;
    private Vector3 _startPosition = Vector3.zero;

    void Start()
    {
        _startPosition = transform.position - _player.position;
    }

    void Update()
    {
        transform.position = _player.position + _startPosition;
    }
}
