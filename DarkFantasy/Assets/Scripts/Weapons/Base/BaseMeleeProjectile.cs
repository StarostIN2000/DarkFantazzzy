using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMeleeProjectile : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    public float destroyAfterSeconds = 1f;

    //currrent stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    private void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            var enemy = collision.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
        }
        else if (collision.CompareTag("props"))
        {
            if (collision.gameObject.TryGetComponent(out BreakableProps prop))
            {
                prop.TakeDamage(currentDamage);
            }
        }
    }
}
