using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Взаимодействие с терминалами
/// </summary>
public class ActivateTerminal : MonoBehaviour
{

    //Ссылка на кнопку взаимодействия
    [SerializeField]
    private GameObject doItButton;

   /// <summary>
   /// Срабатывает при взаимодействии с триггером и проверяет возможность активации терминала
   /// </summary>
   /// <param name="other">Ссылка на персонажа</param>
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Other = "+ other.tag);
        Debug.Log("Current = "+ CurrentPlayer.currentPlayer.tag);

        if (!NotInHacked())
        {
            GetComponent<BoxCollider>().enabled = false;
        }

        if (CurrentPlayer.currentPlayer != null)
            CurrentPlayer.spyForGameProcess.GetComponent<MissionProcess>().currentTerminal = transform.gameObject;
        Debug.Log("Other = " + other.tag);

        if (other.tag == CurrentPlayer.currentPlayer.tag && NotInHacked())
            doItButton.SetActive(true);
        else
            doItButton.SetActive(false);
    }


    /// <summary>
    /// Проверяет не был ли взломан этот терминал ранее
    /// </summary>
    /// <returns>
    /// true - не был взломан
    /// false - уже взломан
    /// </returns>
    private bool NotInHacked()
    {
        foreach (var item in CurrentPlayer.HackedTerminals)
        {
            if (name == item)
                return false;
        }
        return true;
    }

    /// <summary>
    /// Срабатывает при выходе из зоны триггера и деактивирует кнопку взлома
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        doItButton.SetActive(false);
    }

    /// <summary>
    /// Выполняется каждый раз при старте и останавливает воспроизведение звука взлома
    /// </summary>
    private void Start()
    {
        GetComponent<AudioSource>().Stop();
    }
}
