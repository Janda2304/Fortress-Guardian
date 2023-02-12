using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private KeyCode pauseKey;
    [HideInInspector] public bool isPaused = false;
    [SerializeField] private GameObject[] medals;


    void Start()
    {
        pauseMenu.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(pauseKey) && !isPaused)
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
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void OnRestartButton()
    {
        Resume();
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    private void Pause()
    {
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        isPaused = true;
    }
    
    private void Resume()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        isPaused = false;
    }
}
