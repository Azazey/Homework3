using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMover : MonoBehaviour
{
    [SerializeField] private CoinGenerator _coinGenerator;
    [SerializeField] private Transform _player;

    private void Update()
    {
        ArrowMovingAtClosestCoin();
    }

    private void ArrowMovingAtClosestCoin()
    {
        Vector3 target = _coinGenerator.GetClosest(transform.position);
        Vector3 toTarget = target - _player.position;
        Vector3 toTargetXZ = new Vector3(toTarget.x, 0f, toTarget.z);
        transform.rotation = Quaternion.LookRotation(toTargetXZ);
    }
}