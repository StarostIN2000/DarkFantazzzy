using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public List<BasePlayerWeapon> weapons;

    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        foreach (BasePlayerWeapon weapon in weapons)
        {
            weapon.UpdateAttack(playerMovement.GetLastNotZeroDirection(), transform.position);
        }
    }

    public void AddWeapon(BasePlayerWeapon weapon)
    {
        weapons.Add(weapon);
    }
}
