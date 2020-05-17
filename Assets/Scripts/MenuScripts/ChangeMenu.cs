using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, осуществляющий перемещение по пунктам меню
/// </summary>
public class ChangeMenu : MonoBehaviour
{
    //ссылка на текущее окно
    [SerializeField]
    private GameObject mainMenu;

    //ссылка на окно, которое требуется отобразить
    [SerializeField]
    private GameObject currentMenu;

    //ссылка на окно, которое надо скрыть
    [SerializeField]
    private GameObject anotherPanel1;

    //ссылка на окно, которое так же надо скрыть
    [SerializeField]
    private GameObject anotherPanel2;


    /// <summary>
    /// Метод, выполняющийся при нажатии на кнопку
    /// </summary>
    public void OnClickBut()
    {
        mainMenu.SetActive(false);
        currentMenu.SetActive(true);
    }

    /// <summary>
    /// Метод, отвечающий за возврат в главное меню
    /// </summary>
    public void ReturnToMenu()
    {
        mainMenu.SetActive(true);
        currentMenu.SetActive(false);
        anotherPanel1?.SetActive(false);
        anotherPanel2?.SetActive(false);
    }
}

