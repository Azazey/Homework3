using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextWriter : MonoBehaviour
{
    [SerializeField] private Text _coinsText;
    [SerializeField] private Text _winText;
    [SerializeField] private SceneLogic _sceneLogic;

    private void Start()
    {
        foreach (var coin in _sceneLogic.Coins)
        {
            coin.Collected += CoinNumberWriter;
        }

        _sceneLogic.Winer += WinWriter;
        CoinNumberWriter();
    }

    private void CoinNumberWriter()
    {
        _coinsText.text = "Монеток осталось собрать: " + _sceneLogic.CoinsCollected + "/" + _sceneLogic.Coins.Count;
    }

    private void WinWriter()
    {
        _winText.enabled = true;
    }
}
