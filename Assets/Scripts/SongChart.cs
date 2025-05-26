using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SongChart : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource music;

    [Header("Notas")]
    public Transform[] spawnPositions;
    public GameObject[] notePrefabs;

    [Header("Archivo de Notas")]
    public string songName = "default_song";

    [Header("Referencia a InputManager")]
    public InputManager inputManager;

    private SongData songData;
    private float songStartTime;
    private int nextNoteIndex = 0;

    private List<NoteObject> activeNotes = new List<NoteObject>();

    private string JsonPath => $"Assets/Charts/{songName}.json";

    void Start()
    {
        LoadNotesFromJson();
        songStartTime = Time.time;

        if (music != null)
            music.Play();
        else
            Debug.LogWarning("AudioSource no asignado en SongChart");
    }

    void Update()
    {
        if (songData == null || nextNoteIndex >= songData.notes.Count)
            return;

        float elapsed = Time.time - songStartTime;
        float fallTime = 3.333f;

        while (nextNoteIndex < songData.notes.Count && songData.notes[nextNoteIndex].time - fallTime <= elapsed)
        {
            SpawnNote(songData.notes[nextNoteIndex]);
            nextNoteIndex++;
        }

        for (int i = activeNotes.Count - 1; i >= 0; i--)
        {
            NoteObject note = activeNotes[i];

            if (note == null)
            {
                activeNotes.RemoveAt(i);
                continue;
            }

            if (note.transform.position.y < 0.5f && !note.IsHittable())
            {
                note.OnMiss();

                if (inputManager != null)
                    inputManager.RemoveNote(note);

                activeNotes.RemoveAt(i);
            }
        }
    }

    void LoadNotesFromJson()
    {
        string path = JsonPath;

        if (!File.Exists(path))
        {
            Debug.LogError("No se encontró el archivo JSON en: " + path);
            songData = new SongData() { notes = new List<NoteData>() };
            return;
        }

        string json = File.ReadAllText(path);
        songData = JsonUtility.FromJson<SongData>(json);

        songData.notes.Sort((a, b) => a.time.CompareTo(b.time));
    }

    void SpawnNote(NoteData note)
    {
        if (note.lane < 0 || note.lane >= spawnPositions.Length)
        {
            Debug.LogWarning("Nota con lane inválido: " + note.lane);
            return;
        }

        GameObject prefab = notePrefabs[note.lane];
        Transform spawnPos = spawnPositions[note.lane];

        GameObject noteObj = Instantiate(prefab, spawnPos.position, Quaternion.identity);
        NoteObject noteScript = noteObj.GetComponent<NoteObject>();
        if (noteScript == null)
        {
            Debug.LogError("El prefab de nota no tiene componente NoteObject");
            return;
        }

        noteScript.lane = note.lane;
        activeNotes.Add(noteScript);

        if (inputManager != null)
        {
            inputManager.RegisterNote(noteScript);
        }
        else
        {
            Debug.LogWarning("InputManager no asignado en SongChart");
        }
    }
}
