using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : BaseBullet
{
    private float speed = 10f;
    private Vector3 direction;

    Rigidbody2D rb;

    public override void Init(Vector3 dir, float sp, float destroyTime)
    {
        speed = sp;
        direction = dir;
        rb = GetComponent<Rigidbody2D>();
        if (destroyTime > 0) Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = direction * speed;
    }

    
}
