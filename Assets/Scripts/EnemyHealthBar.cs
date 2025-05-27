using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image healthFillImage;
    public float maxHealth = 15450f;

    public float CurrentHealth { get { return currentHealth; } }
    public float MaxHealth { get { return maxHealth; } }


    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthFillImage != null)
        {
            healthFillImage.fillAmount = 1f; // Asegura que empiece llena
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthFillImage != null)
        {
            healthFillImage.fillAmount = currentHealth / maxHealth;
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
