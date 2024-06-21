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
    private Transform _target;
    [SerializeField] private float _moveSpeed;

    private void Start()
    {
        _healthScript = GetComponent<Health>();
        _target = FindObjectOfType<PlayerMovement>().transform;
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
        _rigidbody.velocity = (_target.position - transform.position).normalized * _moveSpeed;
    }

    void Die()
    {
        Destroy(gameObject);//
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var col = collision.GetComponent<BulletMoving>();
        if (col)
        {
            _healthScript.GetDamage(1);
        }
    }


}


