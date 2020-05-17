using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Работа с вступительной сценой
/// </summary>
public class ContinueIntro : MonoBehaviour, IPointerDownHandler
{
    /// <summary>
    /// При нажатии на кнопку описание уровня закрывается
    /// </summary>
    /// <param name="eventData">Информация о событии</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("Intro").SetActive(false);
    }
}
