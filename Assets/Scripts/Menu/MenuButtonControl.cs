using BayatGames.SaveGameFree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonControl : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject newGameMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject exitMenu;
    private GameObject curMenu;


    private void Start()
    {
        settingsMenu.SetActive(false);
        newGameMenu.SetActive(false);
        exitMenu.SetActive(false);
        
        mainMenu.SetActive(true);
        curMenu = mainMenu;
    }
    
    public void NewGame()
    {
        curMenu.SetActive(false);
        newGameMenu.SetActive(true);
        curMenu = newGameMenu;
    }
    
    public void Settings()
    {
        curMenu.SetActive(false);
        settingsMenu.SetActive(true);
        curMenu = settingsMenu;
    }
    
    public void Exit()
    {
        curMenu.SetActive(false);
        exitMenu.SetActive(true);
        curMenu = exitMenu;
    }

    public void BackToMenu()
    {
        curMenu.SetActive(false);
        mainMenu.SetActive(true);
        curMenu = mainMenu;
    }


    public void QuitGame()
    {
        #if UNITY_STANDALONE
        Application.Quit();
        #endif
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        
       
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Continue()
    {
        
    }

    public void ResetTutorial()
    {
        PlayerPrefs.SetBool("ReturningPlayer", false);
    }
    
}
