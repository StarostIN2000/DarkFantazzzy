using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    public float speed = 10f; // �������� �������� �������
    private Transform player; // ������ �� Transform ������

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // ������� ������ �� ���� "Player"
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
            transform.Translate(moveDirection * speed * Time.deltaTime); // ������� ������ � ����������� ������
        }
        else
        {
            Destroy(gameObject); // ���������� ������, ���� ����� �� ������
        }
    }

    
}
