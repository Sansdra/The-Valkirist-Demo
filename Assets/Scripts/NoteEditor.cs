using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class NoteEditor : MonoBehaviour
{
    public AudioSource music;
    public string songName = "default_song"; // Asignalo en el Inspector

    public KeyCode[] laneKeys = { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F };
    public Transform[] previewSpawns;
    public GameObject[] notePreviewPrefabs;

    private List<NoteData> noteChart = new List<NoteData>();
    private bool isRecording = false;

    private float[] noteHoldStartTimes = new float[4]; // Tiempo de inicio por carril
    private bool[] isHolding = new bool[4]; // Si se está manteniendo una tecla

    void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (!music.isPlaying)
        {
            music.Play();
            isRecording = true;
        }
        else
        {
            music.Pause();
            isRecording = false;
        }
    }

    if (isRecording)
    {
        for (int i = 0; i < laneKeys.Length; i++)
        {
            if (Input.GetKeyDown(laneKeys[i]))
            {
                AddNote(i, music.time, 0f);  // duración siempre 0
                Instantiate(notePreviewPrefabs[i], previewSpawns[i].position, Quaternion.identity);
            }
        }
    }

    if (Input.GetKeyDown(KeyCode.Return)) // Guardar con ENTER
    {
        SaveChartToJson($"Assets/Charts/{songName}.json");
    }
}


    void AddNote(int lane, float time, float duration)
    {
        NoteData note = new NoteData { lane = lane, time = time, duration = duration };
        noteChart.Add(note);
        Debug.Log($"Nota agregada en lane {lane} @ {time:F2}s con duración {duration:F2}s");
    }

    void SaveChartToJson(string path)
    {
        string json = JsonUtility.ToJson(new SongData { notes = noteChart }, true);
        File.WriteAllText(path, json);
        Debug.Log("¡Notas guardadas en " + path + "!");
    }
}
