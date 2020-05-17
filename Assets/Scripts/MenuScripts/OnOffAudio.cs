using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Включение/отключение звуков в игре
/// </summary>
public class OnOffAudio : MonoBehaviour
{

    private float volume;

    /// <summary>
    /// Выполняется при старте скрипта и по возможности загружает сохраненные настройки звука
    /// </summary>
    private void Start()
    {
        //if (PlayerPrefs.HasKey("VolumeSettings"))
        //{
        //    volume = PlayerPrefs.GetFloat("VolumeSettings");
        //}
        //else
        //{
        //    volume = 1f;
        //}
        if (PlayerPrefs.HasKey("Volume"))
        {
            switch (PlayerPrefs.GetInt("Volume"))
            {
                case 1:
                    GetComponent<Toggle>().isOn =true;
                    break;
                case 0:
                    GetComponent<Toggle>().isOn = false;
                    break;
            }
            //ValueChanged();
        }   
    }

    /// <summary>
    /// Включает или выключает звуки в игре
    /// </summary>
    public void ValueChanged()
    {
        if (GetComponent<Toggle>().isOn)
        {
            AudioListener.pause = false;
            //AudioListener.volume = volume;
            PlayerPrefs.SetInt("Volume", 1);

        }
        else
        {
            AudioListener.pause = true;
            //AudioListener.volume = 0;
            PlayerPrefs.SetInt("Volume", 0);

        }
    }

}
