using UnityEngine;

public class NoteDamageDealer : MonoBehaviour
{
    private EnemyHealthBar enemyHealthBar;

    private void Start()
    {
        // Busca el script de la barra de vida en la escena
        enemyHealthBar = FindObjectOfType<EnemyHealthBar>();
        if (enemyHealthBar == null)
        {
            Debug.LogError("EnemyHealthBar no encontrado en la escena.");
        }
    }

    public void DealDamage(string judgement)
    {
        if (enemyHealthBar == null) return;

        float damage = 0f;

        switch (judgement)
        {
            case "Perfect":
                damage = 50f;
                break;
            case "Good":
                damage = 25f;
                break;
            case "Ok":
                damage = 10f;
                break;
            case "Miss":
                damage = 0f;
                break;
        }

        enemyHealthBar.TakeDamage(damage);
    }
}
