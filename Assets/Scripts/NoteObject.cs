using UnityEngine;
using System.Collections.Generic;

public class NoteObject : MonoBehaviour
{
    public int lane;

    private HashSet<string> currentZones = new HashSet<string>();
    private bool wasHit = false;

    public bool IsHittable()
    {
        return currentZones.Count > 0;
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
        if (wasHit) return;
        wasHit = true;

        string judgement = GetJudgement();
        Debug.Log($"Nota acertada con {judgement}");

        ScoreManager.Instance.RegisterHit(judgement);

        JudgementDisplay display = FindObjectOfType<JudgementDisplay>();
    if (display != null)
        display.ShowJudgement(judgement);

    Destroy(gameObject);
    }

    public void OnMiss()
    {
        if (wasHit) return;
        wasHit = true;

        Debug.Log("Nota Miss");
        ScoreManager.Instance.RegisterHit("Miss");

        JudgementDisplay display = FindObjectOfType<JudgementDisplay>();
        if (display != null)
        {
            display.ShowJudgement("Miss");
        }

        Destroy(gameObject);
    }
}
