using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonControl : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject newGameMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject exitMenu;


    private void Start()
    {
        mainMenu.SetActive(true);
        newGameMenu.SetActive(false);
        settingsMenu.SetActive(false);
        exitMenu.SetActive(false);
    }
    
    public void NewGame()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(true);
        settingsMenu.SetActive(false);
        exitMenu.SetActive(false);
    }
    
    public void Settings()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(false);
        settingsMenu.SetActive(true);
        exitMenu.SetActive(false);
    }
    
    public void Exit()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(false);
        settingsMenu.SetActive(false);
        exitMenu.SetActive(true);
    }

    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        newGameMenu.SetActive(false);
        settingsMenu.SetActive(false);
        exitMenu.SetActive(false);
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
    
}
