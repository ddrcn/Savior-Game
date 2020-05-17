using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Класс, отвечающий за количество персонажей на уровне, количество взломанных терминалов и хранящий ссылку на текущего персонажа.
/// </summary>
public class CurrentPlayer : MonoBehaviour, IPointerDownHandler
{

    public static GameObject currentPlayer; // ссылка на текущего персонажа
    public static int numPlayer; // номерной знак персонажа
    public static int countOfPlayers; // кол-во персонажей
    private static List<string> terminalNames; // список взломанных терминалов
    public static GameObject spyForGameProcess; // ссылка на внешний объект, отслеживающий состояния других объектов и персонажей


    /// <summary>
    /// Смена персонажей
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {

        if (numPlayer == 1)
        {
            currentPlayer = GameObject.FindGameObjectWithTag("Player2");
            numPlayer = 2;
        }
        else
        {
            currentPlayer = GameObject.FindGameObjectWithTag("Player");
            numPlayer = 1;
        }

    }

    /// <summary>
    /// Инициализация переменных и подсчет персонажей на уровне
    /// </summary>
    void Start()
    {
        currentPlayer = GameObject.FindGameObjectWithTag("Player");
        spyForGameProcess = GameObject.FindGameObjectWithTag("Spy");
        numPlayer = 1;
        terminalNames = new List<string>();
        if (GameObject.FindGameObjectWithTag("Player2") == null)
        {
            countOfPlayers = 1;
        }
        else
            countOfPlayers = 2;
        
    }

    /// <summary>
    /// Добавление терминала в список взломанных
    /// </summary>
    /// <param name="name">название терминала</param>
    public static void Addterminal(string name)
    {
        terminalNames.Add(name);
    }

    /// <summary>
    /// Возвращает список взломанных терминалов
    /// </summary>
    public static List<string> HackedTerminals
    {
        get
        {
            return terminalNames;
        }
    }
}
