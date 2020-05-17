using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Настройка графики в игре
/// </summary>
public class GraphicSettings : MonoBehaviour
{

    //Ссылка на выпадающий список
    [SerializeField]
    public Dropdown dp;

    /// <summary>
    /// Метод, устанавливающий низкие настройки графики
    /// </summary>
    private void LowQuality()
    {
        QualitySettings.SetQualityLevel(1, true);
    }

    /// <summary>
    /// Метод, устанавливающий средние настройки графики
    /// </summ
    private void MediumQuality()
    {
        QualitySettings.SetQualityLevel(2, true);
    }

    /// <summary>
    /// Метод, устанавливающий высокие настройки графики
    /// </summ
    private void HighQuality()
    {
        QualitySettings.SetQualityLevel(4, true);
    }


    /// <summary>
    /// Метод, срабатывающий при изменении значения качества графики
    /// </summary>
    public void ValueChanged()
    {
        switch (dp.value)
        {
            case 0:
                LowQuality();
                break;
            case 1:
                MediumQuality();
                break;
            case 2:
                HighQuality();
                break;
        }
        PlayerPrefs.SetInt("GraphicLevel", dp.value);
    }

    /// <summary>
    /// Срабатывает при первом старте скрипта
    /// </summary>
    private void Start()
    {
        if (dp != null)
        {
            if (PlayerPrefs.HasKey("GraphicLevel"))
            {
                dp.value = PlayerPrefs.GetInt("GraphicLevel");
            }

            ValueChanged();
        }

    }


}
