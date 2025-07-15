using System;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] Behaviour[] disableWhenDie;

    [SerializeField] private float currentHealth;

    public event Action OnDamage; //C sharp szintu Event -> ha oda irjuk hogy event akkor nem lehet kivulrol invokeolni -> Action egy delegate -> Ez lehet Func is, akkor van visszateres
            
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public float MaxHealth => maxHealth;
    

    public float CurrentHealth
    {
        get => currentHealth;
        //return currentHealth;
        set
        {
            if (currentHealth == value) return;

            currentHealth = value;
            OnHealthChange();
        }
    }
    /*
    public void SetCurrentHealth(float value)
    {
        if (currentHealth == value) return;

        currentHealth = value;
        OnHealthChange();
    }
    */

    public void Damage(float damage)
    {
        currentHealth -= damage;
        OnHealthChange();
    }

    private void OnHealthChange()
    {


        //if(OnDamage != null) -> ez az a ?. operator
        OnDamage?.Invoke(); //nem Unity Event

        if (currentHealth <= 0)
        {
            foreach (Behaviour b in disableWhenDie)
                b.enabled = false;
        }
    }
}
