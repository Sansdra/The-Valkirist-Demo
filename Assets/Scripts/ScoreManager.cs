using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int perfectCount = 0;
    public int goodCount = 0;
    public int okCount = 0;
    public int missCount = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Eliminar duplicados
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Opcional: conservar entre escenas
    }

    public void RegisterHit(string accuracy)
    {
        switch (accuracy)
        {
            case "Perfect":
                perfectCount++;
                break;
            case "Good":
                goodCount++;
                break;
            case "Ok":
                okCount++;
                break;
            case "Miss":
                missCount++;
                break;
        }

        Debug.Log($"Perfect: {perfectCount}, Good: {goodCount}, Ok: {okCount}, Miss: {missCount}");
    }
}
