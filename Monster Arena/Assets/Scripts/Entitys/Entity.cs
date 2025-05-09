using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entity : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int maxHealth { get; set; } = 100;

    [field: SerializeField]
    public int currentHealth { get; set; }

    //UI reference to a health bar
    [field: SerializeField]
    public HealthBar healthBar;

    //When this takes damage, should it display damage text?
    //if no prefab is assigned, it will not display damage text
    private bool displayDamageText;
    public GameObject damageTextPrefab;

    public Action OnDeath;
    public Action<int> OnDamageTaken;

    protected virtual void Start()
    {
        if (damageTextPrefab != null)
        {
            displayDamageText = true;
        }

        currentHealth = maxHealth;

        if(healthBar)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }
public void Death(){
        OnDeath?.Invoke();
    }

    public void TakeDamage(int damage,Vector3 spawnPos = default(Vector3))
    {
        if (displayDamageText)
        {
            //If no spawn position is provided, use the entity's position
            if (spawnPos == default(Vector3))
            {
                spawnPos = transform.position;
            }
            spawnPos.x += UnityEngine.Random.Range(-1f, 1f);
            GameObject prefab = Instantiate(damageTextPrefab, spawnPos, Quaternion.identity);
            prefab.GetComponent<UpdateText>().textToDisplay = damage.ToString();
        }
        currentHealth -= damage;

        if(healthBar)
        {
            healthBar.SetCurrentHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Death();
            return;
        }

        //Emit an event that we took damage
        //This can be used to trigger a camera shake or other effects
        OnDamageTaken?.Invoke(damage);
    }

    public void HealDamage(int damage)
    {
        currentHealth += damage;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(healthBar)
        {
            healthBar.SetCurrentHealth(currentHealth);
        }
    }

    protected virtual void Update()
    {
        //For testing purposes, press G to take damage
        if(Input.GetKeyDown(KeyCode.G)){
            TakeDamage(11);
        }
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}