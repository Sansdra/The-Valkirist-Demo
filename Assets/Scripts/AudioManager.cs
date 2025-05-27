using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Test Sound")]
    public AudioClip testSFX;

    private float musicVolume = 1f;
    private float sfxVolume = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

            ApplyVolumes();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        ApplyVolumes();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
        ApplyVolumes();
        PlayTestSFX(); // Opcional: para feedback auditivo al mover el slider
    }

    public void SetGeneralVolume(float volume)
    {
        musicVolume = volume;
        sfxVolume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
        ApplyVolumes();
        PlayTestSFX(); // Opcional: para feedback auditivo al mover el slider
    }

    private void ApplyVolumes()
    {
        if (musicSource != null)
            musicSource.volume = musicVolume;

        if (sfxSource != null)
            sfxSource.volume = sfxVolume;
    }

    public void PlayTestSFX()
    {
        if (sfxSource != null && testSFX != null)
            sfxSource.PlayOneShot(testSFX);
    }
}
