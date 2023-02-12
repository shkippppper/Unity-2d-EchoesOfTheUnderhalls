using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGold : MonoBehaviour
{
    public int coinAmount;
    public TextMeshProUGUI coinText;
    public bool doubleGold = false;
    public bool midas = false;

    private void Start()
    {
        PlayerPrefs.GetInt("Coins");
    }

    private void Update()
    {
        UpdateUI();

    }

    public void UpdateUI()
    {
        coinText.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    public void AddCoin(int amount)
    {
        if (doubleGold)
        {
            amount = amount * 2;
        }
        coinAmount = 0;
        int avaliableCoins = PlayerPrefs.GetInt("Coins");
        coinAmount += amount;
        PlayerPrefs.SetInt("Coins", avaliableCoins + coinAmount);
    }

    public void LoseCoin(int amount)
    {
        int availableCoins = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.SetInt("Coins", availableCoins - amount);
    }
}
