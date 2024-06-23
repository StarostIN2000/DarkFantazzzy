using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField] GameObject prefab;
    public GameObject Prefab { get { return prefab; } private set { prefab = value; } }
    [SerializeField] float damage;
    public float Damage { get { return damage; } private set { damage = value; } }

    [SerializeField] float speed;
    public float Speed { get { return speed; } private set { speed = value; } }

    [SerializeField] float cooldownDuration;
    public float CooldownDuration { get { return cooldownDuration; } private set { cooldownDuration = value; } }

    [SerializeField] int pierce;
    public int Pierce { get { return pierce; } private set { pierce = value; } }

}
