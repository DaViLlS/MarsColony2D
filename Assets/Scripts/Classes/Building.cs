using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : ScriptableObject
{
    [SerializeField] private int Id;
    [SerializeField] private string Name;
    [SerializeField] private string Description;
    [SerializeField] private float Price;
    [SerializeField] private Sprite Image;

    public string GetName => Name;
    public string GetDescr => Description;
    public float GetPrice => Price;
    public Sprite GetImage => Image;
}
