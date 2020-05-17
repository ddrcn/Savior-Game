using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Меню паузы в игре
/// </summary>
public class Pause : MonoBehaviour, IPointerDownHandler
{
    //Ссылка на панель меню паузы
    [SerializeField]
    private GameObject pauseMenu;

    /// <summary>
    /// Ставит игру на паузу по нажатию на кнопку паузы
    /// </summary>
    /// <param name="eventData">данные о событии</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
}
