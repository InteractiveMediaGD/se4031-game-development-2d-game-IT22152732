using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image healthFill;
    [SerializeField] private TMP_Text healthText;

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        float fillAmount = (float)currentHealth / maxHealth;

        healthFill.fillAmount = fillAmount;
        healthText.text = "Health: " + currentHealth + " / " + maxHealth;

        healthFill.color = Color.Lerp(Color.red, Color.green, fillAmount);
    }
}