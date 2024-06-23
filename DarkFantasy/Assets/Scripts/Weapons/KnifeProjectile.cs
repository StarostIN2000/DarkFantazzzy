using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeProjectile : BaseProjectile
{
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * currentSpeed * Time.deltaTime;
    }
}
