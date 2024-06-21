using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    public float speed = 10f; // Скорость движения снаряда
    private Transform player; // Ссылка на Transform игрока

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // Находим игрока по тегу "Player"
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (player != null)
        {
            Vector3 moveDirection = (player.position - transform.position).normalized;
            transform.Translate(moveDirection * speed * Time.deltaTime); // Двигаем снаряд в направлении игрока
        }
        else
        {
            Destroy(gameObject); // Уничтожаем снаряд, если игрок не найден
        }
    }

    
}
