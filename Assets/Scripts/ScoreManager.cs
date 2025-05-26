using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int perfectCount = 0;
    private int goodCount = 0;
    private int okCount = 0;
    private int missCount = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RegisterHit(string judgement)
    {
        switch (judgement)
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

        Debug.Log($"Perfect: {perfectCount} / Good: {goodCount} / Ok: {okCount} / Miss: {missCount}");
    }

    public void ResetScores()
    {
        perfectCount = goodCount = okCount = missCount = 0;
    }
}
