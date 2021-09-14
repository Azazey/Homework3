using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _speedRotation;

    private bool _isCollected;

    public event Action Collected;

    private void Awake()
    {
        transform.Rotate(90, 0, Random.Range(0f, 360f));
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, _speedRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && !_isCollected)
        {
            Destroy(gameObject);
            Collected?.Invoke();
            _isCollected = true;
        }
    }
}