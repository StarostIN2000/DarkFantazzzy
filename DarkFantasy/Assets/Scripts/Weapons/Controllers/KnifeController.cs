using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : BaseWeapon
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedProjectile = Instantiate(weaponData.Prefab, transform.position, Quaternion.identity);
        spawnedProjectile.GetComponent<KnifeProjectile>().DirectionCheck(pm.GetLastNotZeroDirection());
    }
}
