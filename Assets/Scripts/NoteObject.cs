using UnityEngine;
using System.Collections.Generic;

public class NoteObject : MonoBehaviour
{
    public int lane;
    public float duration = 0f; // duración de la nota (0 = normal)

    public Transform holdBar; // visual para nota sostenida (opcional)

    private HashSet<string> currentZones = new HashSet<string>();
    public bool hit = false; // indica si la nota ya fue golpeada

    private float spawnTime;
    private float holdStartTime;
    private bool isBeingHeld = false;

    public float holdTimer => isBeingHeld ? Time.time - holdStartTime : 0f;

    void Start()
    {
        spawnTime = Time.time;

        if (duration > 0f && holdBar != null)
        {
            float speed = 12f; // Ajusta a la velocidad real del juego
            float holdLength = duration * speed;

            holdBar.localScale = new Vector3(1f, holdLength, 1f);
            holdBar.localPosition = new Vector3(0f, -holdLength / 2f, 0f);
            holdBar.gameObject.SetActive(true);
        }
        else if (holdBar != null)
        {
            holdBar.gameObject.SetActive(false);
        }
    }

    public void RegisterZone(string zoneName)
    {
        currentZones.Add(zoneName);
    }

    public void UnregisterZone(string zoneName)
    {
        currentZones.Remove(zoneName);
    }

    public string GetJudgement()
    {
        if (currentZones.Contains("Perfect")) return "Perfect";
        if (currentZones.Contains("Good")) return "Good";
        if (currentZones.Contains("Ok")) return "Ok";
        return "Miss";
    }

    public void OnHit()
    {
        if (hit) return; // ya fue golpeada, no contar otra vez

        hit = true;

        string result = GetJudgement();
        Debug.Log($"Nota {name} golpeada con: {result}");
        ScoreManager.Instance.RegisterHit(result);

        if (duration == 0f)
        {
            // Nota simple, destruimos inmediatamente
            Destroy(gameObject);
        }
        else
        {
            // Nota sostenida, comenzamos el hold
            isBeingHeld = true;
            holdStartTime = Time.time;
        }
    }

    public float GetHeldTime()
    {
        return holdTimer;
    }
}
