using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject generator;
    [SerializeField] private GameObject electroShield;
    [SerializeField] private GameObject _errorText;
    [SerializeField] private MoneyShower moneyText;
    private Vector3 _mousePosition;
    private Player _money;

    private void Start()
    {
        _money = GameObject.Find("Player").GetComponent<Player>();

    }

    public void SpawnBuilding(Button button)
    {
        string name = button.GetComponentsInChildren<Text>()[0].text;
        float price = float.Parse(button.GetComponentsInChildren<Text>()[1].text);

            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            switch (name)
            {
                case "Generator":
                if (_money.money >= price) 
                { 
                    Instantiate(generator, _mousePosition, generator.transform.rotation);
                    _money.money -= price;
                    moneyText.ShowMoney(_money.money);
                }
                else
                {
                    _errorText.SetActive(true);
                    StartCoroutine(ShowMessage());
                }
                    break;
                case "Shield":
                if (_money.money >= price) 
                { 
                    Instantiate(electroShield, _mousePosition, generator.transform.rotation);
                    _money.money -= price;
                    moneyText.ShowMoney(_money.money);
                }
                else
                {
                    _errorText.SetActive(true);
                    StartCoroutine(ShowMessage());
                }
                    break;
            }
    }

    IEnumerator ShowMessage()
    {
        yield return new WaitForSeconds(5);
        _errorText.SetActive(false);
    }
}
