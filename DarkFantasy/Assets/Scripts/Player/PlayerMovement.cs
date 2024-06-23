    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 _lastNotZeroMoveDirection = Vector2.right;

    [HideInInspector] public Vector2 _moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = _moveDirection * moveSpeed;
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
