using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    protected Vector2 direction;
    public float destroyAfterSeconds = 1f;

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
}
