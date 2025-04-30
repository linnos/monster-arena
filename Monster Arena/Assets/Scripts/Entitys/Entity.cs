using System;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int maxHealth { get; set; } = 100;

    [field: SerializeField]
    public int currentHealth { get; set; }

    private void Start() {
        currentHealth = maxHealth;
    }

    public void Death()
    {
        //Trigger death
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0){
            Death();
        }
    }
}