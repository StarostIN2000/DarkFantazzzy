using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    

    

    private Vector2 _lastNotZeroMoveDirection = Vector2.right;

    [HideInInspector] public Vector2 _moveDirection;


    Rigidbody2D rb;
    public CharacterScriptableObject characterData;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = _moveDirection * characterData.MoveSpeed;
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        _moveDirection = new Vector2(horizontalInput, verticalInput).normalized;


        UpdateLastNotZeroDirection();
    }

    void UpdateLastNotZeroDirection()
    {
        if(_moveDirection.sqrMagnitude > 0)
        {
            _lastNotZeroMoveDirection = _moveDirection;
        }
    }
    public Vector2 GetMoveDirection()
    {
        return _moveDirection;
    }
    public Vector2 GetLastNotZeroDirection()
    {
        return _lastNotZeroMoveDirection;
    }
}
