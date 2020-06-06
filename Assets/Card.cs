using System;
using UnityEngine;

public class Card : MonoBehaviour
{
    public float flipTime = 1f;
    
    private SpriteRenderer _imageSprite;
    private bool _isFlipped;
    private bool _matched;
    private bool _isTimed;
    private float _timeFlipped;

    private Action<Card> _flipCallBack;
    private Action<Card> _flipTimeoutCallBack;

    void Start()
    {
        _imageSprite = GetComponent<SpriteRenderer>();
    }

    public void SetCallBack(Action<Card> flipCardCallback, Action<Card> flipTimeoutCallback)
    {
        _flipCallBack = flipCardCallback;
        _flipTimeoutCallBack = flipTimeoutCallback;
    }

    public void MoveTimerStart()
    {
        _isTimed = true;
    }

    private void Update()
    {
        if (_isFlipped && !_matched && _isTimed)
        {
            _timeFlipped += Time.deltaTime;
            if (_timeFlipped > flipTime)
            {
                FlipCard();
                _isTimed = false;
                _flipTimeoutCallBack(this);
            }
        }
    }

    public void FlipCard(bool callBack=false)
    {
        if (!_matched)
        {
            _isFlipped = !_isFlipped;
            _imageSprite.enabled = _isFlipped;
            _timeFlipped = 0f;
            if(callBack)
                _flipCallBack(this);
        }
    }

    public void MatchCard()
    {
        _matched = true;
    }

    private void OnMouseDown()
    {
        FlipCard(true);
    }
}
