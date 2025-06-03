using TMPro;
using UnityEngine;

public class JudgementTextWave : MonoBehaviour
{
    public float waveAmplitude = 5f;
    public float waveFrequency = 10f;

    private TextMeshProUGUI tmp;
    private bool isWaving = false;
    private float elapsed = 0f;
    private float duration = 0f;
    private string originalText;

    void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        if (tmp != null)
            originalText = tmp.text;
    }

    public void StartWave(float waveDuration)
    {
        if (tmp == null) return;

        originalText = tmp.text;
        isWaving = true;
        elapsed = 0f;
        duration = waveDuration;
    }

    void Update()
    {
        if (!isWaving || tmp == null || string.IsNullOrEmpty(originalText))
            return;

        elapsed += Time.deltaTime;
        if (elapsed > duration)
        {
            tmp.text = originalText;
            isWaving = false;
            return;
        }

        string wavedText = "";
        float time = Time.time * waveFrequency;
        for (int i = 0; i < originalText.Length; i++)
        {
            char c = originalText[i];
            float offsetY = Mathf.Sin(time + i * 0.3f) * waveAmplitude;
            wavedText += $"<voffset={offsetY}px>{c}</voffset>";
        }
        tmp.text = wavedText;
    }
}
