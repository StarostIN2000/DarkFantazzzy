using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeProjectile : BaseProjectile
{
    KnifeController kc;
    protected override void Start()
    {
        base.Start();
        kc = FindObjectOfType<KnifeController>();
    }

    void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * kc.speed * Time.deltaTime;
    }
}
