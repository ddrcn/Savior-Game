using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Загрузка новых сцен
/// </summary>
public class NewScene : MonoBehaviour
{

    [SerializeField]
    private GameObject winWindow; //окно выигрыша

    [SerializeField]
    private int levelNumber; //номер текущей игровой сцены

    /// <summary>
    /// При попадании в коллайдер сработает триггер, откроющий экран удачного завершения уровня и разблокируется следующий уровень
    /// </summary>
    /// <param name="other">Ссылка на персонажа в коллайдере</param>
    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        winWindow.SetActive(true);
        if (PlayerPrefs.GetInt("OpenLevels") == levelNumber)
            PlayerPrefs.SetInt("OpenLevels", levelNumber + 1);
    }


}

