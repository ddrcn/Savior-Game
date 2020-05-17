using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Вывод значения таймера на экран
/// </summary>
public class ReadTimer : MonoBehaviour
{
    float timer; //значение таймера
    [SerializeField]
    Text timerText; //ссылка на текстовое представление таймера

    /// <summary>
    /// Инициализация
    /// </summary>
    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().GetTimer;
        timerText.color = Color.green;
    }


    /// <summary>
    /// Обновление таймера на экране пользователя, задание цвета таймера
    /// </summary>
    void Update()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().GetTimer;
        if (timerText != null)
        {
            timerText.text = string.Format("{0:f0}:{1:f0}", Mathf.Round(timer / 60), timer - timer / 60);
        }
        if(timer<=10)
            timerText.color = Color.red;
    }
}
