using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// Класс, отвечающий за работу фонарика
/// </summary>
public class MiniLight : MonoBehaviour, IPointerDownHandler
{

    public GameObject light; //ссылка на источник света для фонарика
    GameObject player; //ссылка на персонажа


    /// <summary>
    /// Срабатывает при нажатии на кнопку фонарика и делает источник света активным/не активным
    /// </summary
    /// <param name="eventData">информация о событии</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if (light != null && light.activeSelf == true)
            light.SetActive(false);
        else if (light != null)
            light.SetActive(true);
    }


    /// <summary>
    /// Инициализация переменных
    /// </summary>
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        light = player.transform.GetChild(7).GetComponent<Light>().gameObject;
    }


    /// <summary>
    /// Меняет ссылку на источник света при смене персонажа
    /// </summary>
    void Update()
    {
        if (player != CurrentPlayer.currentPlayer)
        {
            player = CurrentPlayer.currentPlayer;
            light = player.transform.GetChild(7).GetComponent<Light>().gameObject;
        }
    }
}
