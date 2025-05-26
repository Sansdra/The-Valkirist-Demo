using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Test SFX")]
    public AudioClip testSFX;

    private float masterVolume = 1f;
    private float musicVolume = 1f;
    private float sfxVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolumes(float master, float music, float sfx)
    {
        masterVolume = master;
        musicVolume = music;
        sfxVolume = sfx;

        musicSource.volume = masterVolume * musicVolume;
        sfxSource.volume = masterVolume * sfxVolume;
    }

    public void PlayTestSFX()
    {
        if (testSFX != null)
        {
            sfxSource.PlayOneShot(testSFX);
        }
    }
}
