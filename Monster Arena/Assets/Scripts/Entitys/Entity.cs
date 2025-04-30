using System;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int maxHealth { get; set; } = 100;

    [field: SerializeField]
    public int currentHealth { get; set; }

    //When this takes damage, should it display damage text?
    //if no prefab is assigned, it will not display damage text
    private bool displayDamageText;
    public GameObject damageTextPrefab;

    private void Start() {
        if(damageTextPrefab != null){
            displayDamageText = true;
        }

        currentHealth = maxHealth;
    }

    public void Death()
    {
        //Trigger death
    }

    public void TakeDamage(int damage)
    {
        if(displayDamageText){
            Vector3 spawnPos = transform.position;
            spawnPos.x += UnityEngine.Random.Range(-1f, 1f);
            GameObject prefab = Instantiate(damageTextPrefab, spawnPos, Quaternion.identity);
            prefab.GetComponent<UpdateText>().textToDisplay = damage.ToString();
        }
        currentHealth -= damage;
        if(currentHealth <= 0){
            Death();
        }
    }
}