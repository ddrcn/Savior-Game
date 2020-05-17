using UnityEngine;

/// <summary>
/// Получение сохраненных настроек ггромкости звука
/// </summary>
public class GetVolumeSettings : MonoBehaviour
{
    /// <summary>
    /// Присваивает объекту AudioListener сохраненные настройки громкости звука
    /// </summary>
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("VolumeSlider");
    }
}
