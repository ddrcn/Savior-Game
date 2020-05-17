using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Работа с окном справки
/// </summary>
public class InfoOpen : MonoBehaviour, IPointerDownHandler
{
    //Ссылка на панель справки
    [SerializeField]
    private GameObject infoPanel;

    /// <summary>
    /// Вызывается при нажатии на кнопку и активирует панель справки
    /// </summary>
    /// <param name="eventData">Информация о событии</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(true);
        }
    }
}
