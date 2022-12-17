using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private GroundTrigger ground;
    [SerializeField] private MoneyShower moneyText;
    public float money;
    private float _time;

    public double GetMoney => money;

    private void Start()
    {
        money = 5;
        _time = 0;
    }

    private void Update()
    {
        _time  += Time.deltaTime;
        if (Convert.ToInt32(_time) == 10)
        {
            money += ground._powerSum / 2;
            Math.Round(money, 2);
            _time = 0;
        }

        moneyText.ShowMoney(money);
    }
}
