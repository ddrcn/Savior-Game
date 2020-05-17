using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Отслеживание нажатий кнопки идти
/// </summary>
public class RunPress : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool pressed; //нажата ли кнопка
    GameObject player; //ссылка на персонажа

    [SerializeField]
    GameObject swipePlayerButton; //ссылка на кнопку смены персонажей

    /// <summary>
    /// При нажатой кнопке ходьбы кнопка смены персонжа не активна
    /// </summary>
    /// <param name="eventData">информация о событии</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
        player.GetComponent<Move>().pressed = true;
        swipePlayerButton.SetActive(false);
    }

    /// <summary>
    /// При отпускании кнопки ходьбы кнопка смены персонжа снова активна
    /// </summary>
    /// <param name="eventData">информация о событии</param>
    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        player.GetComponent<Move>().pressed = false;
        if(CurrentPlayer.countOfPlayers==2)
            swipePlayerButton.SetActive(true);

    }

    /// <summary>
    /// Инициализация
    /// </summary>
    void Start()
    {
        pressed = false;
        player = CurrentPlayer.currentPlayer;
    }

    /// <summary>
    /// Смена ссылок на персонажа
    /// </summary>
    void Update()
    {

        if (player != CurrentPlayer.currentPlayer)
        {
            player = CurrentPlayer.currentPlayer;
        }
    }
}
