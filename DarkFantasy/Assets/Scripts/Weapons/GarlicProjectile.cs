using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicProjectile : BaseMeleeProjectile
{
    List<GameObject> markedEnemies;
    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") && !markedEnemies.Contains(collision.gameObject))
        {
            var enemy = collision.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);

            markedEnemies.Add(collision.gameObject);
        }
    }
}
