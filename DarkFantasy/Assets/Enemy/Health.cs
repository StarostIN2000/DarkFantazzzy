using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float _maxHealth;
    [SerializeField] public float _startHealth;
    [SerializeField] public float _currentHealth;

    private void Awake()
    {
        _currentHealth = _startHealth == 0 ? _maxHealth : _startHealth;
    }
    public bool IsAlive()
    {
        return _currentHealth > 0;
    }

    public void GetDamage(float d)
    {
        _currentHealth = Mathf.Max(_currentHealth - d, 0);
    }

    public void GetHeal(float d)
    {
        _currentHealth = Mathf.Min(_currentHealth + d, _maxHealth);
    }
}
