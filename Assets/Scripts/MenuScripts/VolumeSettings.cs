using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Настройки громкости в игре
/// </summary>
public class VolumeSettings : MonoBehaviour
{
    //Ссылка на источник звука
    [SerializeField]
    private GameObject audioSource;

    //Ссылка на слайдер для настройки громкости
    [SerializeField]
    private Slider slider;

    /// <summary>
    /// Выполняется при первом обращении к скрипту и по возможности загружает сохраненные настройки звука
    /// </summary>
    void Start()
    {
        if (PlayerPrefs.HasKey("VolumeSlider"))
        {
            //audioSource.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("VolumeSlider");
            AudioListener.volume = PlayerPrefs.GetFloat("VolumeSlider");
            slider.value= PlayerPrefs.GetFloat("VolumeSlider");
        }
        else
        {
            slider.value = 1f;
            //audioSource.GetComponent<AudioSource>().volume = 1f;
            AudioListener.volume = 1f;
        }

        if (PlayerPrefs.HasKey("Volume"))
        {
            switch (PlayerPrefs.GetInt("Volume"))
            {
                case 1:
                    AudioListener.pause = false;
                    break;
                case 0:
                    AudioListener.pause = true ;
                    break;
            }
        }
    }

    /// <summary>
    /// Выполняется при изменение значения слайдера громкости
    /// </summary>
    /// <param name="vol">Новое значение громкости</param>
    public void OnValueChanged(float vol)
    {
        AudioListener.volume = vol;
        PlayerPrefs.SetFloat("VolumeSlider", vol);
    }

}
