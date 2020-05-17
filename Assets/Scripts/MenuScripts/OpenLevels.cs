using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Отвечает за работу окна выбора уровней
/// </summary>
public class OpenLevels : MonoBehaviour, IPointerDownHandler
{

    //Номер текущей сцены
    [SerializeField]
    private int levelNumber;

    //Ссылка на картинку, если уровень доступен
    [SerializeField]
    private Sprite imgSourceOpen;

    //Ссылка на картинку, если уровень не доступен
    [SerializeField]
    private Sprite imgSourceClose;

    //Создан ли уровень
    [SerializeField]
    private bool notCreated;

    //Открыт ли текущий уровень
    private bool isOpen;

    /// <summary>
    /// При нажатии на кнопку загружает текущую сцену
    /// </summary>
    /// <param name="eventData">данные о событии</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if (isOpen)
        {
            GameObject.FindGameObjectWithTag("MenuSettings").GetComponent<MenuSettings>().LoadScene(levelNumber);
        }
    }

    /// <summary>
    /// Выполняется при старте скрипта и по возможности достает из сохранений открытые игроком сцены
    /// </summary>
    void Start()
    {
        if (!PlayerPrefs.HasKey("OpenLevels"))
        {
            PlayerPrefs.SetInt("OpenLevels", 1);
        }
        isOpen = false;
    }

    /// <summary>
    /// Задает цвета и картинки кнопкам выбора уровня
    /// </summary>
    void Update()
    {
        if (notCreated)
        {
            GetComponent<Image>().color = new Color32(255, 255, 255, 255); ;
            GetComponent<Image>().sprite = imgSourceClose;
            isOpen = false;
        }
        else if(PlayerPrefs.HasKey("OpenLevels") && PlayerPrefs.GetInt("OpenLevels") >= levelNumber)
        {
            GetComponent<Image>().color = new Color32(153, 255, 175, 255);
            GetComponent<Image>().sprite = imgSourceOpen;
            isOpen = true;
        }
        else
        {
            GetComponent<Image>().color = new Color32(255, 180, 153, 255); ;
            GetComponent<Image>().sprite = imgSourceClose;
            isOpen = false;
        }
        Debug.Log(PlayerPrefs.GetInt("OpenLevels"));
    }
}
