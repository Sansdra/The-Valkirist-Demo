using UnityEngine;
using UnityEngine.UI;

public class RadialMenuController : MonoBehaviour
{
    [Header("Opciones del menú radial")]
    public RectTransform[] options;
    public float radius = 150f;
    public float rotationSpeed = 5f;

    [Header("Escala de selección")]
    public float scaleSelected = 1.4f;
    public float scaleNormal = 0.9f;

    [Header("Icono central")]
    public RectTransform centerIcon;
    public float bounceScale = 1.2f;
    public float bounceSpeed = 8f;

    private int targetIndex = 0;
    private float currentRotation = 0f;

    private float bounceTimer = 0f;
    private bool bouncing = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetIndex = (targetIndex + 1) % options.Length;
            StartBounce();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetIndex = (targetIndex - 1 + options.Length) % options.Length;
            StartBounce();
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        {
            SelectOption();
        }

        float targetRotation = -targetIndex * (360f / options.Length);
        currentRotation = Mathf.LerpAngle(currentRotation, targetRotation, Time.deltaTime * rotationSpeed);

        PositionOptions(currentRotation);
        HighlightOption();
        AnimateBounce();
    }

    void PositionOptions(float angleOffset)
    {
        float angleStep = 360f / options.Length;
        for (int i = 0; i < options.Length; i++)
        {
            float angle = (i * angleStep + angleOffset) * Mathf.Deg2Rad;
            Vector2 pos = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
            options[i].anchoredPosition = pos;
        }
    }

    void HighlightOption()
    {
        for (int i = 0; i < options.Length; i++)
        {
            float scale = (i == targetIndex) ? scaleSelected : scaleNormal;
            options[i].localScale = Vector3.Lerp(options[i].localScale, Vector3.one * scale, Time.deltaTime * 10f);

            Image img = options[i].GetComponent<Image>();
            if (img != null)
                img.color = (i == targetIndex) ? Color.white : new Color(1f, 1f, 1f, 0.5f);
        }
    }

    void SelectOption()
    {
        Debug.Log("Seleccionaste: " + options[targetIndex].name);
    }

    void StartBounce()
    {
        bounceTimer = 0f;
        bouncing = true;
    }

    void AnimateBounce()
    {
        if (bouncing && centerIcon != null)
        {
            bounceTimer += Time.deltaTime * bounceSpeed;
            float scale = 1f + Mathf.Sin(bounceTimer * Mathf.PI) * (bounceScale - 1f);
            centerIcon.localScale = new Vector3(scale, scale, 1f);

            if (bounceTimer >= 1f)
            {
                centerIcon.localScale = Vector3.one;
                bouncing = false;
            }
        }
    }
}
