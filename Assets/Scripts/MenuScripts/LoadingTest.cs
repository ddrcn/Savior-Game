using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Окно загрузки между сценами
/// </summary>
public class LoadingTest : MonoBehaviour
{
    // Выполняется при первом обращении к скрипту и запускает метод с ассинхронной загрузкой сцены
    void Start()
    {
        StartCoroutine(DoAsync());
    }

    /// <summary>
    /// Ассинхронная загрузка сцены
    /// </summary>
    /// <returns></returns>
    IEnumerator DoAsync()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(0);
        Debug.Log(loading);
        //loadPanel.SetActive(true);
        while (!loading.isDone)
        {
            Debug.Log(loading.progress);
            yield return null;
        }
    }
}
