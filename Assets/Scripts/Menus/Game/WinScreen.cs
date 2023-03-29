using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameUI;
    public bool isGameWon;
    [SerializeField] private PauseManager _pause;

    public void Win()
    {
        _pause.Pause();
        pauseScreen.SetActive(false);
        gameUI.SetActive(false);
        isGameWon = true;
        Cursor.lockState = CursorLockMode.None;
    }


    public void MainMenu()
    {
        isGameWon = false;
        winScreen.SetActive(false);
        _pause.Resume();
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Continue()
    {
        isGameWon = false;
        AutoLoad.Enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        _pause.Resume();
        Time.timeScale = 1;
        winScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    void Update()
    {
        print("isWon?" + isGameWon);
    }
    
    
}
