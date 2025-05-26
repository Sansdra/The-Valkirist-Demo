using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform notesParent; // Padre donde se instancian las notas
    public float missThresholdY = 0.5f; // Coordenada Y a partir de la cual se considera Miss

    private InputManager inputManager;

    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
    }

    void Update()
    {
        if (notesParent == null || inputManager == null)
            return;

        // Recorremos todas las notas activas
        foreach (Transform noteTransform in notesParent)
        {
            NoteObject note = noteTransform.GetComponent<NoteObject>();
            if (note == null)
                continue;

            // Si la nota pasó la posición miss y no fue golpeada aún
            if (noteTransform.position.y < missThresholdY)
            {
                Debug.Log($"Nota {note.name} Miss por pasar de Y={missThresholdY}");
                note.OnMiss();
                inputManager.RemoveNote(note);
            }
        }
    }
}
