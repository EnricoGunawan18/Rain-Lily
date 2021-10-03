using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript3 : MonoBehaviour
{
    [SerializeField]
    Button retryButton;
    [SerializeField]
    Button returnMenuButton;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TogglePause);
        retryButton.onClick.AddListener(RetryGame);
        returnMenuButton.onClick.AddListener(QuitGame);
    }

    public void TogglePause()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RetryGame()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage3");
    }

    public void QuitGame()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }
}
