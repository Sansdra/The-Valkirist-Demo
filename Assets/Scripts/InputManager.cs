using UnityEngine;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
    public KeyCode[] laneKeys = { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F };
    public JudgementDisplay judgementDisplay;

    private List<NoteObject>[] laneNotes;

    void Start()
    {
        laneNotes = new List<NoteObject>[laneKeys.Length];
        for (int i = 0; i < laneKeys.Length; i++)
        {
            laneNotes[i] = new List<NoteObject>();
        }
    }

    void Update()
    {
        for (int i = 0; i < laneKeys.Length; i++)
        {
            if (Input.GetKeyDown(laneKeys[i]))
            {
                if (laneNotes[i].Count > 0)
                {
                    NoteObject note = laneNotes[i][0];

                    if (!note.hit)
                    {
                        note.OnHit();

                        string judgement = note.GetJudgement();

                        if (judgementDisplay != null)
                        {
                            judgementDisplay.ShowJudgement(judgement);
                        }

                        laneNotes[i].RemoveAt(0);
                    }
                }
            }
        }
    }

    public void RegisterNote(NoteObject note)
    {
        if (note.lane >= 0 && note.lane < laneNotes.Length)
        {
            laneNotes[note.lane].Add(note);
        }
        else
        {
            Debug.LogWarning($"Nota con lane inválido: {note.lane}");
        }
    }

    public void UnregisterNote(NoteObject note)
    {
        if (note.lane >= 0 && note.lane < laneNotes.Length)
        {
            laneNotes[note.lane].Remove(note);
        }
    }
}
