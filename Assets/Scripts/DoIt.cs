using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Кнопка взаимодействия
/// </summary>
public class DoIt : MonoBehaviour, IPointerDownHandler
{
    /// <summary>
    /// При нажатии на кнопку взаимодействия вызывается метод, обрабатывающий это действие
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        CurrentPlayer.spyForGameProcess.GetComponent<MissionProcess>().DoMission();
    }
}
