using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PlayerController.isGameOver)
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }       
    }
    public void RestartGame()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1f;
        }
        gameIsPaused = false;
        PlayerController.isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
        }
        gameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
