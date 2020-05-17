using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Следит за процессом выполнения поставленных задач
/// </summary>
public class MissionProcess : MonoBehaviour
{
    private bool complitedMissions; //выполненные миссии
    public GameObject currentTerminal; //ссылка на текущий терминал

    [SerializeField]
    private int missionCount; //общее кол-во миссий

    [SerializeField]
    private GameObject doItButton; //ссылка на кнопку взаимодействия

    [SerializeField]
    private GameObject finalDoor; //ссылка на дверь, открывающуюся при выполнении всех задач

    [SerializeField]
    private float openSpeed; //скорость открытия двери

    [SerializeField]
    private GameObject finalLamp; //зеленый свет на место завершения уровня

    [SerializeField]
    private Text tasksText; //список заданий

    /// <summary>
    /// Инициализация переменных
    /// </summary>
    void Start()
    {
        complitedMissions = false;
        finalLamp.SetActive(false);
        
    }

    /// <summary>
    /// Обновление состояния заданий
    /// </summary>
    void Update()
    {
         tasksText.text = $"\tВзломайте {missionCount} терминала: ({CurrentPlayer.HackedTerminals.Count}/{missionCount})";

        if (complitedMissions)
        {
            tasksText.text = $"\tВзломайте {missionCount} терминала: ({CurrentPlayer.HackedTerminals.Count}/{missionCount})\n\nВыбирайтесь с уровня, следуя зелёному огню";
            OpenFinalDoor();
        }
    }

    /// <summary>
    /// Выполнить задание по взлому текущего терминала
    /// </summary>
    public void DoMission()
    {
        CurrentPlayer.Addterminal(currentTerminal.name);
        currentTerminal.GetComponent<AudioSource>().Play();
        complitedMissions = CurrentPlayer.HackedTerminals.Count == missionCount;
    }

    /// <summary>
    /// Открыть финальную дверь для возможности завершить уровень
    /// </summary>
    private void OpenFinalDoor()
    {
        finalDoor.transform.Translate(new Vector3(0, Time.deltaTime*openSpeed, 0));
        if (finalDoor.transform.position.y < -1.2)
        {
            finalLamp.SetActive(true);
        }
    }
}
