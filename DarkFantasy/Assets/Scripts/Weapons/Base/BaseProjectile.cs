using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    protected Vector2 direction;
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

    public void DirectionCheck(Vector2 dir)
    {
        direction = dir;
        float rot = transform.rotation.eulerAngles.z;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.x, direction.y) * -Mathf.Rad2Deg + 90);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            var enemy = collision.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
            ReducePierce();
        }
        else if (collision.CompareTag("props"))
        {
            if(collision.gameObject.TryGetComponent(out BreakableProps prop))
            {
                prop.TakeDamage(currentDamage);
                ReducePierce();
            }
        }
    }

    void ReducePierce()
    {
        currentPierce--;
        if(currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
