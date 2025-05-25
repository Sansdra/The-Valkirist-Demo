using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SongChart : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource music; // El AudioSource que reproduce la canción

    [Header("Notas")]
    public Transform[] spawnPositions; // Posiciones de spawn (4)
    public GameObject[] notePrefabs;   // Prefabs de nota (4), uno por carril

    [Header("Archivo de Notas")]
    public string songName = "default_song"; // Asignalo desde el Inspector

    [Header("Referencia a InputManager")]
    public InputManager inputManager;

    private SongData songData;
    private float songStartTime;

    private int nextNoteIndex = 0;

    private string JsonPath => $"Assets/Charts/{songName}.json";

    void Start()
    {
        LoadNotesFromJson();
        songStartTime = Time.time;

        if (music != null)
        {
            music.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource no asignado en SongChart");
        }
    }

    void Update()
    {
        if (songData == null || nextNoteIndex >= songData.notes.Count)
            return;

        float elapsed = Time.time - songStartTime;

        float fallTime = 2f; // Tiempo que tarda la nota en caer (distancia/velocidad)

        while (nextNoteIndex < songData.notes.Count && songData.notes[nextNoteIndex].time - fallTime <= elapsed)
        {
            SpawnNote(songData.notes[nextNoteIndex]);
            nextNoteIndex++;
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
