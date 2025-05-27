using UnityEngine;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
    public KeyCode[] laneKeys = { KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I };
    public JudgementDisplay judgementDisplay;

    private List<NoteObject>[] laneNotes;

    void Start()
    {
        laneNotes = new List<NoteObject>[4];
        for (int i = 0; i < 4; i++)
            laneNotes[i] = new List<NoteObject>();
    }

    void Update()
    {
        for (int i = 0; i < laneKeys.Length; i++)
        {
            if (Input.GetKeyDown(laneKeys[i]))
            {
                if (laneNotes[i].Count == 0)
                {
                    Debug.Log($"Presionaste tecla {laneKeys[i]}, pero no hay notas en lane {i}");
                    continue;
                }

                NoteObject note = laneNotes[i][0];

                if (note == null)
                {

                    laneNotes[i].RemoveAt(0);
                    Debug.LogWarning($"Nota nula removida de lane {i}");
                    continue;
                }

                if (note.IsHittable())
                {
                    string judgement = note.GetJudgement();
                    note.OnHit();

                    if (judgementDisplay != null)
                        judgementDisplay.ShowJudgement(judgement);

                        NoteDamageDealer dealer = FindObjectOfType<NoteDamageDealer>();
                        if (dealer != null)
                            dealer.DealDamage(judgement);

                    laneNotes[i].RemoveAt(0);
                }
                else
                {
                    Debug.Log("Presionaste fuera de zona activa, no se registra hit.");
                    // Opcional: si quieres que toque contar como Miss, puedes llamar aquí a ScoreManager.
                }
            }
        }
    }

    public void RegisterNote(NoteObject note)
    {
        laneNotes[note.lane].Add(note);
    }

    public void RemoveNote(NoteObject note)
    {
        if (note == null)
            return;

        if (laneNotes[note.lane].Contains(note))
            laneNotes[note.lane].Remove(note);
    }
}

