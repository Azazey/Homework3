using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody _rigidbody;

    private const float FLerpSpeed = 10f;

    private List<Vector3> _velocitiesList = new List<Vector3>();

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            _velocitiesList.Add(Vector3.zero);
        }
    }

    private void FixedUpdate()
    {
        _velocitiesList.Add(_rigidbody.velocity);
        _velocitiesList.RemoveAt(0);
    }

    private void Update()
    {
        CameraRotationAndMoving();
    }

    private void CameraRotationAndMoving()
    {
        Vector3 summ = Vector3.zero;
        for (int i = 0; i < _velocitiesList.Count; i++)
        {
            summ += _velocitiesList[i];
        }

        transform.position = _transform.position;
        transform.rotation =
            Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(summ), Time.deltaTime * FLerpSpeed);
    }
}