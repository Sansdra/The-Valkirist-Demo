using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AutoCanvasCreator : MonoBehaviour
{
    [Header("Canvas Options")]
    public RenderMode canvasRenderMode = RenderMode.ScreenSpaceOverlay;

    [Header("Judgement Text Options")]
    public string defaultText = "";
    public int fontSize = 64;
    public Color fontColor = Color.white;
    public float displayTime = 0.6f;

    public Font GetFont;

    private GameObject canvasGO;

    void Start()
    {
        SpawnCanvasWithJudgementText();
    }

    void SpawnCanvasWithJudgementText()
    {
        // Crear Canvas
        canvasGO = new GameObject("AutoCanvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = canvasRenderMode;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Crear Texto TMP
        GameObject textGO = new GameObject("JudgementText");
        textGO.transform.SetParent(canvasGO.transform);

        RectTransform rectTransform = textGO.AddComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.sizeDelta = new Vector2(600, 200);
        rectTransform.localScale = Vector3.one;

        TextMeshProUGUI tmp = textGO.AddComponent<TextMeshProUGUI>();
        tmp.text = defaultText;
        tmp.fontSize = fontSize;
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.color = fontColor;

        // Añadir JudgementDisplay
        JudgementDisplay display = canvasGO.AddComponent<JudgementDisplay>();
        display.displayTime = displayTime;

        // Asignar el TMP al script JudgementDisplay usando reflexión
        typeof(JudgementDisplay)
            .GetField("judgementText", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(display, tmp);
    }

    void OnDestroy()
    {
        if (canvasGO != null)
            Destroy(canvasGO);
    }
}
