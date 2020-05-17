using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Вступительная сцена перед началом игрового уровня
/// </summary>
public class Introduction : MonoBehaviour
{

    [SerializeField]
    private string text; // текст, который напечатается пользователю
    int count; // количество напечатанных букв

    /// <summary>
    /// Инициализация
    /// </summary>
    void Start()
    {
        Time.timeScale = 0; //ставим игровое время на паузу
        count = 0;
    }

    /// <summary>
    /// Каждый кадр печатаем игроку новую букву(выводим текст с эффектом набора через клавиатуру)
    /// </summary>
    void Update()
    {
        if (count < text.Length)
        {
            if (text[count] == ' ')
                GetComponentInChildren<Text>().text += "\t\t";
            GetComponentInChildren<Text>().text += text[count];
            count++;
        }
    }
}
