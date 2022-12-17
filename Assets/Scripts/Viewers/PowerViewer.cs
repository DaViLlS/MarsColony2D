using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerViewer : MonoBehaviour
{
    private Text _powerText;

    private void Start()
    {
        _powerText = GetComponent<Text>();
    }

    public void ChangeText(float power)
    {
        _powerText.text = "Power: " + power.ToString();
    }
}
