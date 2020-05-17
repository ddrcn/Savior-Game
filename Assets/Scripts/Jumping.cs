using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// Класс, отвечающих за прыжок персонажа
/// </summary>
public class Jumping : MonoBehaviour, IPointerDownHandler
{

    public GameObject character; //ссылка на текущего персонажа

    /// <summary>
    /// При нажатии на кнопку вызывается метод, обрабатывающий прыжок персонажа
    /// </summary>
    /// <param name="eventData">Информация о событии</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        character.GetComponent<Move>().Jumping();
    }

    /// <summary>
    /// Инициализация переменных
    /// </summary>
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
    }

    /// <summary>
    /// Изменяет ссылку в локальной переменной при смене персонажа
    /// </summary>
    void Update()
    {
        if (character != CurrentPlayer.currentPlayer)
        {
            character = CurrentPlayer.currentPlayer;
        }
    }
}
