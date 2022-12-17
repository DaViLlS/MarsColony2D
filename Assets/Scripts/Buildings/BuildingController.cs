using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    [SerializeField] public Building building;
    public bool isPlaceable;
    private bool isMovable;
    private Vector3 _mousePosition;
    private Transform _generatorPos;
    private SpriteRenderer _genColor;

    private void Start()
    {
        _generatorPos = GetComponent<Transform>();
        _genColor = GetComponent<SpriteRenderer>();
        isPlaceable = false;
        isMovable = true;
    }

    private void Update()
    {
        if (isMovable)
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            FollowMouse();
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        if (isPlaceable && isMovable)
        {
            _genColor.color = new Color(0, 255, 0);
        }
        else if (isPlaceable == false && isMovable)
        {
            _genColor.color = new Color(255, 0, 0);
        }
        else
        {
            _genColor.color = new Color(255, 255, 255);
        }
    }

    public void FollowMouse()
    {
        _generatorPos.position = new Vector3(_mousePosition.x, _mousePosition.y, 0);
    }

    public void ChangeStatement()
    {
        isMovable = false;
        ChangeColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BuildingController>())
        {
            isPlaceable = false;
            ChangeColor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BuildingController>())
        {
            isPlaceable = true;
            ChangeColor();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<BuildingController>())
        {
            isPlaceable = false;
            ChangeColor();
        }
    }
}
