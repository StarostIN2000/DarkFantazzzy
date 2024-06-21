using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    private Vector3 _lastNotZeroDirection = Vector3.right;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;
        rb.velocity = movement;

        UpdateLastNotZeroDirection();
    }

    void UpdateLastNotZeroDirection()
    {
        if(rb.velocity.sqrMagnitude > 0)
        {
            _lastNotZeroDirection = rb.velocity.normalized;
        }
    }
    public Vector3 GetMoveDirection()
    {
        return rb.velocity.normalized;
    }
    public Vector3 GetLastNotZeroDirection()
    {
        return _lastNotZeroDirection;
    }
}
