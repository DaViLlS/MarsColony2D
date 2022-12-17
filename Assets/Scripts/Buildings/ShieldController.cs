using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField] private ElectroShield electroShield;
    private PowerViewer _powerViewer;
    [SerializeField] private Sprite shieldOn;
    [SerializeField] private Sprite shieldOff;
    private Animator _anim;
    private GroundTrigger _ground;
    private bool isOffed;
    private SpriteRenderer _curSprite;
    private BoxCollider2D _shieldRange;
    private Vector2 _offsetOn;
    private Vector2 _offsetOff;
    private Vector2 _sizeOn;
    private Vector2 _sizeOff;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _powerViewer = GameObject.Find("Power Text").GetComponent<PowerViewer>();
        _ground = GameObject.Find("Mars").GetComponent<GroundTrigger>();
        _curSprite = GetComponent<SpriteRenderer>();
        _shieldRange = GetComponent<BoxCollider2D>();
        isOffed = true;
        _offsetOn = new Vector2(-0.02947593f, -0.1555011f);
        _offsetOff = new Vector2(-0.002002895f, -0.2881761f);
        _sizeOn = new Vector2(5.544671f, 3.12569f);
        _sizeOff = new Vector2(1.033028f, 0.2418829f);
    }

    private void OnMouseDown()
    {
        if ((_ground._powerSum >= electroShield.GetEatablePower) && (isOffed == true))
        {
            ActivateShield();
            _ground._powerSum -= electroShield.GetEatablePower;
            _powerViewer.ChangeText(_ground._powerSum);
            isOffed = false;
        }
        else if (isOffed == false)
        {
            DeactivateShield();
            _ground._powerSum += electroShield.GetEatablePower;
            _powerViewer.ChangeText(_ground._powerSum);
            isOffed = true;
        }
    }

    private void ActivateShield()
    {
        _anim.SetBool("isClicked", true);
        _shieldRange.offset = _offsetOn;
        _shieldRange.size = _sizeOn;
    }

    private void DeactivateShield()
    {
        _anim.SetBool("isClicked", false);
        _shieldRange.offset = _offsetOff;
        _shieldRange.size = _sizeOff;
    }
}
