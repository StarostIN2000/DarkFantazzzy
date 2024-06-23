using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _animator;
    PlayerMovement _playerMovement;
    SpriteRenderer _spriteRenderer;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerMovement._moveDirection.sqrMagnitude != 0)
        {
            _animator.SetBool("move", true);
            CheckSpriteDirection();
        }
        else
        {
            _animator.SetBool("move", false);
        }
    }

    void CheckSpriteDirection()
    {
        var lastDir = _playerMovement.GetLastNotZeroDirection().x;
        if (lastDir > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if(lastDir < 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
