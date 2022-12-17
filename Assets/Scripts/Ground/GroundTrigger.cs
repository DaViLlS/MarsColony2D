using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private PowerViewer powerText;
    [SerializeField] private Generator generatorObj;
    private BuildingController building;
    public float _powerSum;
    public bool isExsiting;

    private void Start()
    {
        isExsiting = false;
        _powerSum = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        building = collision.GetComponent<BuildingController>();
        if (building != null)
        {
            isExsiting = true;
            building.isPlaceable = true;
            building.ChangeColor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        building.isPlaceable = false;
        building.ChangeColor();
    }

    private void OnMouseDown()
    {
        if (isExsiting && building.isPlaceable)
        {
            building.ChangeStatement();
            if (building.building.GetName == "Generator")
            {
                _powerSum += generatorObj.GetPower;
                powerText.ChangeText(_powerSum);
            }
            isExsiting = false;
        }
    }
}
