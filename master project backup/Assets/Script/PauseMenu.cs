using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject Crosshair;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
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

    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Crosshair.SetActive(true);
    }
    void Pause()
    {
        Crosshair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Debug.Log("loading menu");
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}

