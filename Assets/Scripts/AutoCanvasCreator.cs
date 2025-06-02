using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoCanvasCreator : MonoBehaviour
{
    [Header("Canvas Options")]
    public RenderMode canvasRenderMode = RenderMode.ScreenSpaceOverlay;

    [Header("Judgement Text Options")]
    public TMP_FontAsset nuevaFuente;
    public int fontSize = 64;
    public Color fontColor = Color.white;
    public float displayTime = 0.6f;

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
        tmp.text = ""; // Texto inicial vacío
        tmp.font = nuevaFuente; // ✅ Fuente asignada
        tmp.fontSize = fontSize;
        tmp.color = fontColor;
        tmp.alignment = TextAlignmentOptions.Center;

        // Añadir JudgementDisplay y conectar texto
        JudgementDisplay display = canvasGO.AddComponent<JudgementDisplay>();
        display.judgementText = tmp; // ✅ Asignación directa
        display.displayTime = displayTime;
    }

    void OnDestroy()
    {
        if (canvasGO != null)
            Destroy(canvasGO);
    }
}
