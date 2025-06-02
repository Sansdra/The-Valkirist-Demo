using UnityEngine;
using TMPro;

public class JuzgementDisplay : MonoBehaviour
{
    public TextMeshProUGUI judgementText;

    public float displayTime = 0.5f;

    private float timer;

   public TMP_FontAsset nuevaFuente;
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
                judgementText.font = nuevaFuente;
                break;
            case "Good":
                judgementText.color = Color.green;
                judgementText.font = nuevaFuente;
                break;
            case "Ok":
                judgementText.color = Color.cyan;
                judgementText.font = nuevaFuente;
                break;
            case "Miss":
                judgementText.color = Color.red;
                judgementText.font = nuevaFuente;
                break;
            default:
                judgementText.color = Color.white;
                judgementText.font = nuevaFuente;
                break;
        }

        timer = displayTime;
    }
}
