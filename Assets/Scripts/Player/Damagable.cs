using System;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] Behaviour[] disableWhenDie;

    [SerializeField] private float currentHealth;
            
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            foreach(Behaviour b in disableWhenDie)
                b.enabled = false;
        }
    }
}
