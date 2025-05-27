using UnityEngine;
using UnityEngine.UI;

public class SoundSettingsUI : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider masterSlider;

    private void Start()
    {
        // Cargar volúmenes guardados
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
        masterSlider.value = masterVolume;

        ApplyVolumes(); // Aplicar volúmenes al iniciar

        // Listeners
        musicSlider.onValueChanged.AddListener(OnMusicChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXChanged);
        masterSlider.onValueChanged.AddListener(OnMasterChanged);
    }

    void OnMusicChanged(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        ApplyVolumes();
    }

    void OnSFXChanged(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", value);
        ApplyVolumes();

        // Reproducir un sonido de prueba
        AudioManager.Instance?.PlayTestSFX();
    }

    void OnMasterChanged(float value)
    {
        PlayerPrefs.SetFloat("MasterVolume", value);
        ApplyVolumes();
    }

    void ApplyVolumes()
    {
        float music = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfx = PlayerPrefs.GetFloat("SFXVolume", 1f);
        float master = PlayerPrefs.GetFloat("MasterVolume", 1f);

        AudioManager.Instance.SetGeneralVolume(master);
        AudioManager.Instance.SetMusicVolume(music);
        AudioManager.Instance.SetSFXVolume(sfx);
    }
}

