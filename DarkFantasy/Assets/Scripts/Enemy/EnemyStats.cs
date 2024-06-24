using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;

    private void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    public void TakeDamage(float d)
    {
        currentHealth -= d;

        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D col) 
    {
        ////Reference the script from the collided collider and deal damage using Take Damage()
        if (col.gameObject.CompareTag("Player")) 
        {
            PlayerStats player = col.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage); //Make sure to use currentDamage instead of weapon Data.damage
        }
    }
}
