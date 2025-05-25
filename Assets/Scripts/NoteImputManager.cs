using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInputManager : MonoBehaviour
{
    public KeyCode[] laneKeys; // Asigna en el inspector (A, S, D, F)
    public Transform[] hitCheckPositions; // Asigna las posiciones en la escena
    public float hitRadius = 1f;

    void Update()
    {
        for (int i = 0; i < laneKeys.Length; i++)
        {
            if (Input.GetKeyDown(laneKeys[i]))
            {
                CheckForHit(i);
            }
        }
    }

    void CheckForHit(int lane)
    {
        Collider[] hits = Physics.OverlapSphere(hitCheckPositions[lane].position, hitRadius);

        foreach (var hit in hits)
        {
            Note note = hit.GetComponent<Note>();
            if (note != null && note.lane == lane)
            {
                string accuracy = note.GetHitAccuracy();
                Debug.Log($"Hit in lane {lane}: {accuracy}");

                Destroy(note.gameObject);
                break;
            }
        }
    }
}
