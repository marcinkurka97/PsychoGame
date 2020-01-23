using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static bool isInCutScene = true;
    public GameObject pauseMenuUI;
	public string currentActiveType;


    private SaveManager _saveManager = new SaveManager();

    void Start() {
        Time.timeScale = 1f;
    }

    void Update()
    {
        ListenForKeyDown();
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    public void ExitToMenu() {
        SceneManager.LoadScene("MainMenu");
        Resume();
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
