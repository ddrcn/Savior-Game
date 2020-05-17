using UnityEngine;

public class Detonator : MonoBehaviour
{
    /// <summary>
    /// Вызывается при каждой смене кадра, останавливает таймер при достижении 0
    /// </summary>
    void Update()
    {
        if (CurrentPlayer.HackedTerminals.Count > 0) 
        {
            GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().isTic = true;
        }
    }
}
