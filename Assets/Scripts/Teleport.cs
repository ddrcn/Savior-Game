using UnityEngine;

/// <summary>
/// Отвечает за телепортацию
/// </summary>
public class Teleport : MonoBehaviour
{
    public bool isArrived; //прибыл ли персонаж к желаемому телепорту

    [SerializeField]
    private bool rotate; //повернуть ли персонажа
    [SerializeField]
    private float rotationFlip; //чему должен быть равен угол после поворота персонажа

    [SerializeField]
    GameObject anotherTP; //ссылка на назначенный телепорт


    /// <summary>
    /// Сработает при входе в триггер телепорта и переместит персонажа к желаемому телепорту
    /// </summary>
    /// <param name="other">Ссылка на персонажа</param>
    private void OnTriggerEnter(Collider other)
    {
        if (!isArrived)
        {
            other.GetComponent<Move>().inTeleporting = true;
            other.transform.position = anotherTP.transform.position;
            anotherTP.GetComponent<Teleport>().isArrived = true;
        }
        else if (rotate)
        {
            GameObject.FindGameObjectWithTag("MainCamera").transform.rotation = Quaternion.Euler(0,rotationFlip,0);
            other.transform.Rotate(0, 180, 0);
        }
    }

    /// <summary>
    /// При выходе из триггера состояние персонажа о телепортировании изменится на ложное
    /// </summary>
    /// <param name="other">Ссылка на персонажа</param>
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Move>().inTeleporting = false;
        isArrived = false;
    }
}
