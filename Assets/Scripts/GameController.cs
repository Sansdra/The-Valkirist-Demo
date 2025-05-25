using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [Header("Audio")]
    public AudioSource music;

    private float startTime;
    private bool songStarted = false;

    public float SongTime => Time.time - startTime;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        StartSong();
    }

    void StartSong()
    {
        startTime = Time.time;
        songStarted = true;

        if (music != null)
        {
            music.Play();
        }
        else
        {
            Debug.LogWarning("No se ha asignado el AudioSource en GameController.");
        }
    }

    void Update()
    {
        if (songStarted && !music.isPlaying && Time.time - startTime > 1f)
        {
            EndSong();
        }
    }

    void EndSong()
    {
        Debug.Log("La canción ha terminado.");
        // Aquí puedes mostrar una pantalla de resultados, reiniciar el nivel, etc.
    }
}
