using UnityEngine;

public class JudgementZone : MonoBehaviour
{
    [Tooltip("Nombre de la zona de juicio: Perfect, Good, Ok, Miss")]
    public string zoneName;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<NoteObject>(out var note))
        {
            note.RegisterZone(zoneName);
            Debug.Log($"Nota {other.name} entró en zona {zoneName}");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<NoteObject>(out var note))
        {
            note.UnregisterZone(zoneName);
            Debug.Log($"Nota {other.name} salió de zona {zoneName}");

            if (zoneName == "Miss")
            {
                // Si la nota sale de la zona Miss sin haber sido golpeada, se cuenta como miss
                if (!note.hit)
                {
                    Debug.Log($"Miss registrado para {note.name}");
                    ScoreManager.Instance.RegisterHit("Miss");
                    Destroy(note.gameObject);
                }
            }
        }
    }
}
