using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    private SaveManager _saveManager = new SaveManager();

    void Update()
    {
        ListenForKeyDown();
    }

    void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    private void ListenForKeyDown()
    {
        ListenForPause();
        ListenForSave();
        ListedForLoad();
    }

    private void ListenForPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void ListenForSave()
    {
        if(Input.GetKeyDown(KeyCode.F5))
        {
            _saveManager.SaveGameState();
        }
    }

    private void ListedForLoad()
    {
        if (Input.GetKeyDown(KeyCode.F6))
        {
            //_saveManager.LoadGameState();
            _saveManager.LoadGameState();
        }

    }
}
