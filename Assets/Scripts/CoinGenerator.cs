using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private const int _coinsPerRoom = 3;

    private List<Coin> _objectsList = new List<Coin>();
    public List<Coin> Generate()
    {
        for (int i = 0; i < _coinsPerRoom; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Vector3 position = new Vector3(PositionGiver(j).x, PositionGiver(j).y, PositionGiver(j).z);
                Coin coin = Instantiate(_coinPrefab, position, Quaternion.identity);
                _objectsList.Add(coin);
            }
        }

        return _objectsList;
    }

    private Vector3 PositionGiver(int i)
    {
        Vector3[] positions =
        {
            new Vector3(Random.Range(6.3f, 42.6f), 5f, Random.Range(174.3f, 222.3f)),
            new Vector3(Random.Range(57.6f, 155.4f), 5f, Random.Range(200.8f, 224.14f)),
            new Vector3(Random.Range(6.3f, 72.2f), 5f, Random.Range(110.4f, 137.2f)),
            new Vector3(Random.Range(118.46f, 155.03f), 5f, Random.Range(109.45f, 185.87f)),
            new Vector3(Random.Range(6.41f, 154.3f), 5f, Random.Range(80.4f, 97.4f)),
            new Vector3(Random.Range(4.6f, 153.3f), 5f, Random.Range(17.44f, 62.6f)),
        };
        return positions[i];
    }

    public Vector3 GetClosest(Vector3 point)
    {
        float minDistance = Mathf.Infinity;
        Vector3 closestCoin = Vector3.zero;
        for (int i = 0; i < _objectsList.Count; i++)
        {
            if (_objectsList[i] != null)
            {
                float distance = Vector3.Distance(point, _objectsList[i].transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestCoin = _objectsList[i].transform.position;
                }
            }
        }

        return closestCoin;
    }
}