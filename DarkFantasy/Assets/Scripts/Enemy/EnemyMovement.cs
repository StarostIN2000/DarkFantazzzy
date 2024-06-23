using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, enemyData.MoveSpeed);
    }
}
