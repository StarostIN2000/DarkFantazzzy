using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    Transform player;
    Rigidbody2D rb;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        rb = GetComponent<Rigidbody2D>();   
    }
    private void FixedUpdate()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.position, enemyData.MoveSpeed); // old move
        Vector2 dir = (player.position - transform.position).normalized;
        rb.velocity = dir * enemyData.MoveSpeed;

        if(dir.sqrMagnitude > 0)
        {
            CheckSpriteDirection(dir);
        }
    }

    void CheckSpriteDirection(Vector2 dir)
    {
        if (dir.x > 0 )
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
