using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Логика для работы меню
/// </summary>
public class MenuSettings : MonoBehaviour
{

    //Ссылка на панель меню паузы
    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject loadPanel;

    [SerializeField]
    private Scrollbar scrollbar;

    [SerializeField]
    private Text loadingStatus;

    /// <summary>
    /// Метод загрузки сцены по выбранному номеру
    /// </summary>
    /// <param name="num">Номер сцены</param>
    public void LoadScene(int num)
    {
        StartCoroutine(LoadingScene(num));
        //SceneManager.LoadScene(num);
        Time.timeScale = 1;


    }

    private IEnumerator LoadingScene(int num)
    {
        loadPanel.SetActive(true);
        AsyncOperation loading = SceneManager.LoadSceneAsync(num);
        while (!loading.isDone)
        {
            scrollbar.size = loading.progress;
            loadingStatus.text = $"{Mathf.RoundToInt(loading.progress*100)} %";
            yield return null;
        }
        loadPanel.SetActive(false);
    }

    /// <summary>
    /// Метод загрузки новой игры (сбрасывает все открытые уровни и загружает первую сцену)
    /// </summary>
    public void NewGame()
    {
        PlayerPrefs.SetInt("OpenLevels", 1);
    }


    /// <summary>
    /// Выход из приложения
    /// </summary>
    public void Exit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    /// <summary>
    /// Перезапуск текущего уровня
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Возврат к текущему уровню из меню паузы
    /// </summary>
    public void ReturnToGame()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
