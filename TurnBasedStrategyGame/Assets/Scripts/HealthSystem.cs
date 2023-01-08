using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public event EventHandler OnDeath;
    public event EventHandler OnDamaged;

    [SerializeField] private int health = 100;
    private int healthMax;

    private void Awake()
    {
        healthMax = health;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health < 0)
        {
            health = 0;
        }

        OnDamaged?.Invoke(this, EventArgs.Empty);

        if(health == 0)
        {
            OnDeath?.Invoke(this, EventArgs.Empty);
        }
    }

    public float GetHealthNormalized()
    {
        return (float) health / healthMax;
    }

}
