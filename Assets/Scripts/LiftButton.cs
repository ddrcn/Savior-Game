using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Отвечает за объект, взаимодействующий с подъемной площадкой
/// </summary>
public class LiftButton : MonoBehaviour
{
    //Ссылка на платформу-лифт
    [SerializeField]
    private GameObject lift;

    //Скорость платформы вверх
    [SerializeField]
    private float liftSpeedUp;
    
    //Скорость платформы вниз
    [SerializeField]
    private float liftSpeedDown;

    /// <summary>
    /// Срабатывает при нахождении персонажа в коллайдере
    /// </summary>
    /// <param name="other">Ссылка на персонажа в коллайдере</param>
    private void OnTriggerStay(Collider other)
    {
        StopAllCoroutines(); //Остановка всех асинхронных методов
        if (lift.transform.position.y > 0.01)
        {
        lift.transform.Translate(new Vector3(0, Time.deltaTime * liftSpeedDown, 0));
        }
    }


    /// <summary>
    /// Срабатывает когда персонаж покидает коллайдер
    /// </summary>
    /// <param name="other">Ссылка на персонажа</param>
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(LiftUp()); //Запуск асинхронного метода для возврата платформы на свою первоначальную позицию
    }

    /// <summary>
    /// Поднимает платформу до определённого уровня
    /// </summary>
    /// <returns></returns>
    IEnumerator LiftUp()
    {
        while(lift.transform.position.y < 7.21)
        {
            lift.transform.Translate(new Vector3(0, Time.deltaTime * liftSpeedUp, 0));
            yield return null;
        }
    }

}
