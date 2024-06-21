using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerWeapon : MonoBehaviour
{
    public float attackRate = 1f;
    public float attackPrefabLifeTime = 3f;
    public float bulletSpeed = 3f;
    public GameObject attackPrefab;

    float nextAttackTime = 0;

    void Attack(Vector3 dir, Vector3 startPos)
    {
        Vector3 direction = dir == Vector3.zero ? Vector3.right : dir;
        GameObject newAttack = Instantiate(attackPrefab, startPos, Quaternion.identity);
        newAttack.GetComponent<BaseBullet>().Init(direction.normalized, bulletSpeed, 5f);
    }

    internal void UpdateAttack(Vector3 dir, Vector3 startPos)
    {
        if (Time.time >= nextAttackTime)
        {
            Attack(dir, startPos);
            nextAttackTime = Time.time + attackRate;
        }
    }
}
