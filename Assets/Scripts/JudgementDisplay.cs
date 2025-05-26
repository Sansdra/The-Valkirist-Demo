using UnityEngine;
using TMPro;

public class JuzgementDisplay : MonoBehaviour
{
    [Header("Texto de Juicio")]
    [SerializeField] public TextMeshProUGUI judgementText;

    [Header("Duración de visualización")]
    public float displayTime = 0.5f;

    private float timer;

    void Start()
    {
        if (judgementText != null)
            judgementText.text = "";
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && judgementText != null)
            {
                judgementText.text = "";
            }
        }
    }

    public void ShowJudgement(string judgement)
    {
        if (judgementText == null)
        {
            Debug.LogWarning("judgementText no asignado en JudgementDisplay");
            return;
        }

        judgementText.text = judgement;

        // Opcional: cambiar color según el tipo de juicio
        switch (judgement.ToLower())
        {
            case "perfect":
                judgementText.color = Color.yellow;
                break;
            case "good":
                judgementText.color = Color.green;
                break;
            case "ok":
                judgementText.color = Color.cyan;
                break;
            case "miss":
                judgementText.color = Color.red;
                break;
            default:
                judgementText.color = Color.white;
                break;
        }

        timer = displayTime;
    }
}
