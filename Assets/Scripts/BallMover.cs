using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _forceValue;
    [SerializeField] private Transform _cameraCenter;

    private const int _accelerationMultyPlyer = 3;

    private void FixedUpdate()
    {
        BallRolling();
    }

    private void BallRolling()
    {
        _rigidbody.AddTorque(_cameraCenter.right * Input.GetAxis("Vertical") * _forceValue);
        _rigidbody.AddTorque(-_cameraCenter.forward * Input.GetAxis("Horizontal") * _forceValue);
    }
}
