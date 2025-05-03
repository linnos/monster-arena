using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    /// <summary>
    /// Sets the maximum value of the stamina bar.  
    /// </summary>
    
    public void SetMaxStamina(float stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetCurrentStamina(float stamina)
    {
        slider.value = stamina;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    
}
