using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackPrefab;
    
    public float attackRate = 1f;

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        Vector3 direction = transform.right; 
        GameObject newAttack = Instantiate(attackPrefab, transform.position, Quaternion.LookRotation(Vector3.forward, direction));
        
    }
}
