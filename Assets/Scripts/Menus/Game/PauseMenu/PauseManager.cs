using System.Collections;
using System.Collections.Generic;
using FG_NewBuildingSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using FG_Saving;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private KeyCode pauseKey;
    public bool isPaused = false;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private BuildingSystem _buildingSystem;
    [SerializeField] private WinScreen _win;


    void Start()
    {
        pauseMenu.SetActive(false);
        gameUI.SetActive(true);
        Resume();
    }
    
    void Update()
    {
        
        if (Input.GetKeyDown(pauseKey) && !isPaused && _win.isGameWon == false && Currency.IsGameLost == false)
        {
            Pause();
        }
        else if (Input.GetKeyDown(pauseKey) && isPaused)
        {
            Resume();
        }
    }


    public void OnResumeButton()
    {
        Resume();
    }

    public void OnMenuButton()
    {
        Resume();
        SaveManage saveManage = FindObjectOfType<SaveManage>();
        saveManage.Save();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }
    



    public void Pause()
    {
        pauseMenu.SetActive(true);
        pause.SetActive(true);
        settingsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        isPaused = true;
        _buildingSystem.buildings[_buildingSystem.index].HidePreview();
        _buildingSystem.isBuilding = false;
    }
    
    public void Resume()
    {
        pauseMenu.SetActive(false);
        pause.SetActive(false);
        gameUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        isPaused = false;
    }

    public void OnSettingsButton()
    {
        pause.SetActive(false);
        settingsMenu.SetActive(true);
        gameUI.SetActive(false);

    }
    
    public void OnBackButton()
    {
        pauseMenu.SetActive(true);
        pause.SetActive(true);
        settingsMenu.SetActive(false);
        gameUI.SetActive(true);
    
    }
}
