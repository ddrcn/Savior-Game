using UnityEngine;

/// <summary>
/// Внутриигровой таймер
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timer; //текущее значение таймера

    private float oldTimer; //изначальное значение таймера

    [SerializeField]
    private GameObject loseWindow; //окно проигрыша

    public bool isTic; //Запущен ли таймер

    /// <summary>
    /// Инициализация
    /// </summary>
    private void Start()
    {
        isTic = false;
        oldTimer = timer;
    }
    
    /// <summary>
    /// Уменьшение значения таймера
    /// </summary>
    void Update()
    {
        if (timer > 0 && isTic)
            timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Time.timeScale = 0;
            loseWindow.SetActive(true);
            timer = oldTimer;
        }
    }

    /// <summary>
    /// Получить текущее значение таймера
    /// </summary>
    public float GetTimer
    {
        get
        {
            return timer;
        }
    }
}
