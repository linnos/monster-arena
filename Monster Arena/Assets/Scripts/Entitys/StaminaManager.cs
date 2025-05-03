using System;
using UnityEngine;

// This class is used to manage the stamina of an entity.
// Set this class to any entity that has stamina.
public class StaminaManager : MonoBehaviour
{
    public float maxStamina;
    public float currentStamina;
    public float staminaRegenRate = 5f; // Stamina regenerated per second
    public float staminaRegenCooldown = 5f; // Time before stamina starts regenerating after use
    private float staminaRegenCooldownTimer = 0f;
    private bool canRegen = false;

    public StaminaBar staminaBar;

    private void Start()
    {
        if (maxStamina <= 0)
        {
            throw new ArgumentException("Max stamina must be greater than 0. Check to see if stamina is set");
        }

        currentStamina = maxStamina;
        staminaRegenCooldownTimer = staminaRegenCooldown;
        if (staminaBar)
        {
            staminaBar.SetMaxStamina(maxStamina);
        }
    }

    private void Update()
    {
        RegenerateStamina();
    }

    private void RegenerateStamina()
    {
        if (!canRegen)
        {
            checkCooldownTimer();
            return;
        }

        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            setStaminaBar(currentStamina);
        }
    }

    public bool UseStamina(float staminaCost)
    {
        if (currentStamina > 0)
        {
            currentStamina -= staminaCost;
            //Clamps stamina to 0 so it doesn't go negative.
            //This is important because if it goes negative, it will not regen properly.
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

            setStaminaBar(currentStamina);
            resetStaminaRegenCooldown();
            
            return true;
        }
        return false;
    }

    //If you cant't regen, start the cooldown timer.
    //Once the cooldown timer is up, you can regen again.
    private void checkCooldownTimer()
    {
        staminaRegenCooldownTimer -= Time.deltaTime;
        if (staminaRegenCooldownTimer <= 0)
        {
            staminaRegenCooldownTimer = staminaRegenCooldown;
            canRegen = true;
        }
    }

    private void setStaminaBar(float stamina)
    {
        if (staminaBar)
        {
            staminaBar.SetCurrentStamina(currentStamina);
        }
    }

    private void resetStaminaRegenCooldown()
    {
        staminaRegenCooldownTimer = staminaRegenCooldown;
        canRegen = false;
    }
}