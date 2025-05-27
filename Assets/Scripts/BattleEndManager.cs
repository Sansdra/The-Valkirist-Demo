using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BattleEndManager : MonoBehaviour
{
    public AudioSource battleMusic;
    public EnemyHealthBar enemyHealthBar;

    [Tooltip("Tiempo en segundos que espera después de que termina la música antes de evaluar.")]
    public float waitAfterSongEnd = 3f;

    [Tooltip("Porcentaje de vida que debe bajar el enemigo para ganar (0.5 = 50%)")]
    public float requiredDamagePercentage = 0.5f;

    [Tooltip("Nombre de la escena a cargar en caso de victoria")]
    public string winSceneName;

    [Tooltip("Nombre de la escena a cargar en caso de derrota")]
    public string loseSceneName;

    private bool hasEvaluated = false;

    void Update()
    {
        if (!hasEvaluated && battleMusic != null && !battleMusic.isPlaying)
        {
            hasEvaluated = true;
            StartCoroutine(EvaluateAfterDelay());
        }
    }

    private IEnumerator EvaluateAfterDelay()
    {
        yield return new WaitForSeconds(waitAfterSongEnd);

        float currentHealth = enemyHealthBar.CurrentHealth; // Necesitamos exponer CurrentHealth en EnemyHealthBar
        float maxHealth = enemyHealthBar.MaxHealth;         // Lo mismo para MaxHealth

        if (currentHealth <= maxHealth * (1f - requiredDamagePercentage))
        {
            // Victoria
            Debug.Log("¡Victoria! Se ha quitado suficiente vida al enemigo.");
            if (!string.IsNullOrEmpty(winSceneName))
                SceneManager.LoadScene(winSceneName);
        }
        else
        {
            // Derrota
            Debug.Log("Derrota... No se quitó suficiente vida.");
            if (!string.IsNullOrEmpty(loseSceneName))
                SceneManager.LoadScene(loseSceneName);
        }
    }
}
