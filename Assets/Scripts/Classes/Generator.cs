using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Generator", menuName = "Buildings/Generator", order = 51)]
public class Generator : Building
{
    [SerializeField] private float Power;

    public float GetPower => Power;
}
