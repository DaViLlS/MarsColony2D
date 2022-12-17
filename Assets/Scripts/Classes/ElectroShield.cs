using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ElectroShield", menuName = "Buildings/ElectroShield", order = 51)]
public class ElectroShield : Building
{
    [SerializeField] private float Defence;
    [SerializeField] private float EatablePower;

    public float GetDefence => Defence;

    public float GetEatablePower => EatablePower;
}
