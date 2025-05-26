using UnityEngine;
using TMPro;

public class JudgementDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI judgementText;

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
        switch (judgement)
        {
            case "Perfect":
                judgementText.color = Color.yellow;
                break;
            case "Good":
                judgementText.color = Color.green;
                break;
            case "Ok":
                judgementText.color = Color.cyan;
                break;
            case "Miss":
                judgementText.color = Color.red;
                break;
            default:
                judgementText.color = Color.white;
                break;
        }

        timer = displayTime;
    }
}
