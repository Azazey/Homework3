using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLogic : MonoBehaviour
{
    [SerializeField] private CoinGenerator _coinGenerator;

    private int _coinsCollected;

    public int CoinsCollected => _coinsCollected;

    private List<Coin> _coins = new List<Coin>();

    public List<Coin> Coins => _coins;

    public event Action Winer;

    private void Awake()
    {
        _coins = _coinGenerator.Generate();
        foreach (var coin in _coins)
        {
            coin.Collected += CoinCounter;
        }
    }

    private void CoinCounter()
    {
        _coinsCollected++;
        WinChecker();
    }

    private void WinChecker()
    {
        if (_coinsCollected == _coins.Count)
        {
            Winer?.Invoke();
        }
    }
}