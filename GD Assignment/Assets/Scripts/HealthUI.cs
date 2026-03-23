using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image healthFill;
    [SerializeField] private TMP_Text healthText;

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        float healthPercent = (float)currentHealth / maxHealth;

        // Update fill amount
        healthFill.fillAmount = healthPercent;

        // Update text
        healthText.text = "Health: " + currentHealth + " / " + maxHealth;

        // Change color based on health
        if (healthPercent > 0.6f)
        {
            healthFill.color = new Color(0.2f, 1f, 0.2f);   // green
        }
        else if (healthPercent > 0.3f)
        {
            healthFill.color = new Color(1f, 0.8f, 0.2f);   // yellow
        }
        else
        {
            healthFill.color = new Color(1f, 0.2f, 0.2f);   // red
        }
    }
}