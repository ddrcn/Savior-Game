using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Вращение камеры по джойстику
/// </summary>
public class CameraOnButton : MonoBehaviour, IDragHandler
{
    
    GameObject cn; // ссылка на главную камеру

    /// <summary>
    /// Инициализируем переменную с ссылкой на главную камеру
    /// </summary>
    void Start()
    {
        cn = GameObject.FindGameObjectWithTag("MainCamera");
    }

    /// <summary>
    /// Вызывается при перемещении пальца по сенсорному джойстику
    /// </summary>
    /// <param name="eventData">информация о событии</param>
    public void OnDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            cn.GetComponent<CameraControl>().DoCam(eventData.delta.x, 0); //поворот по x
        }
        else
        {
            cn.GetComponent<CameraControl>().DoCam(0, eventData.delta.y); //поворот по y
        }
    }

}