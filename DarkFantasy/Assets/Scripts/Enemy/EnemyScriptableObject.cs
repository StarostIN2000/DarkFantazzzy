using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyScriptableObject : ScriptableObject
{
    float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } private set { moveSpeed = value; } }
    float maxHealth;
    public float MaxHealth { get { return maxHealth; } private set { maxHealth = value; } }
    float damage;
    public float Damage { get { return damage; } private set { damage = value; } }
}
