using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyShower : MonoBehaviour
{
    private Text _moneyText;

    private void Start()
    {
        _moneyText = GetComponent<Text>();
    }

    public void ShowMoney(float money)
    {
        _moneyText.text = "Money: " + Math.Round(money, 2).ToString();
    }
}