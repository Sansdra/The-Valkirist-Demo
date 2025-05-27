using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour

{
    public enum VolumeType { Music, SFX, General }
    public VolumeType type;

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        switch (type)
        {
            case VolumeType.Music:
                slider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
                slider.onValueChanged.AddListener(AudioManager.Instance.SetMusicVolume);
                break;

            case VolumeType.SFX:
                slider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
                slider.onValueChanged.AddListener(AudioManager.Instance.SetSFXVolume);
                break;

            case VolumeType.General:
                float avg = (PlayerPrefs.GetFloat("MusicVolume", 1f) + PlayerPrefs.GetFloat("SFXVolume", 1f)) / 2f;
                slider.value = avg;
                slider.onValueChanged.AddListener(AudioManager.Instance.SetGeneralVolume);
                break;
        }
    }
}
