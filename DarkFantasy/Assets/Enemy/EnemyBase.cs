using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface EnemyDef
{
    void Move() { }
    void Die() { }
    void IsAlive() { }
}

public class EnemyBase : MonoBehaviour, EnemyDef
{
    private Health _healthScript;
    private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed;

    private void Start()
    {
        _healthScript = GetComponent<Health>();
        _target = FindObjectOfType<Player>().transform;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();

        if (!_healthScript.IsAlive())
        {
            Die();
        }
    }

    void Move()
    {
        _rigidbody.velocity = Vector2.MoveTowards(transform.position, _target.position, 2) * _moveSpeed;
    }

    void Die()
    {
        Destroy(gameObject);//
    }


}


