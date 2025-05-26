using UnityEngine;

public class JudgementZone : MonoBehaviour
{
    public string zoneType; // "Perfect", "Good", "Ok"

    private void OnTriggerEnter(Collider other)
    {
        NoteObject note = other.GetComponent<NoteObject>();
        if (note != null)
        {
            note.RegisterZone(zoneType);
            // Debug.Log($"{note.name} entró en zona {zoneType}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        NoteObject note = other.GetComponent<NoteObject>();
        if (note != null)
        {
            note.UnregisterZone(zoneType);
            // Debug.Log($"{note.name} salió de zona {zoneType}");
        }
    }
}
