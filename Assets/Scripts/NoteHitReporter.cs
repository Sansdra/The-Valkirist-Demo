using UnityEngine;

public class NoteHitReporter : MonoBehaviour
{
    private NoteDamageDealer damageDealer;

    private void Start()
    {
        damageDealer = FindObjectOfType<NoteDamageDealer>();
    }

    public void ReportHit(string judgement)
    {
        if (damageDealer != null)
        {
            damageDealer.DealDamage(judgement);
        }
    }
}
