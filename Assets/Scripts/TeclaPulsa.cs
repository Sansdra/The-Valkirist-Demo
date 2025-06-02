using UnityEngine;

public class HaloEffect : MonoBehaviour
{
    public float duration = 0.5f;
    public float maxScale = 2f;

    private Vector3 initialScale;
    private float timer;
    private SpriteRenderer sr;

    void Start()
    {
        initialScale = transform.localScale;
        timer = 0f;
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = timer / duration;

        transform.localScale = Vector3.Lerp(initialScale, Vector3.one * maxScale, t);

        if (sr != null)
        {
            Color c = sr.color;
            c.a = Mathf.Lerp(1f, 0f, t);
            sr.color = c;
        }

        if (t >= 1f)
            Destroy(gameObject);
    }
}
