using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ShopViewer : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private SpawnManager spawner;
    private Shop _shop;
    private Text[] buttonText;

    private void Start()
    {
        _shop = GetComponent<Shop>();
        ShowItems();
    }

    void ShowItems()
    {
        const float yPosOffset = 90f; 
        float offsetCounter = 0; 
        for (int i = 0; i < _shop.items.Count; i++)
        {
            GameObject tempObj = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity) as GameObject; 

            tempObj.name = "Button" + i;
            tempObj.transform.SetParent(_panel.transform, false);
            Button tempButton = tempObj.GetComponent<Button>();

            //Добавить дочерние объекты в массив а потом уже изменить их текст
            buttonText = tempObj.GetComponentsInChildren<Text>();
            tempObj.GetComponentsInChildren<Image>()[1].sprite = _shop.items[i].GetImage;
            buttonText[0].text = _shop.items[i].GetName;
            buttonText[1].text = _shop.items[i].GetPrice.ToString();

            Vector2 pos = Vector2.zero; 
            pos.y = offsetCounter;
            tempButton.GetComponent<RectTransform>().anchoredPosition = pos;
            Debug.Log(buttonText[0].text);
            tempButton.onClick.AddListener(() => spawner.SpawnBuilding(tempButton)); 
            offsetCounter += yPosOffset;
        }
    }
}
