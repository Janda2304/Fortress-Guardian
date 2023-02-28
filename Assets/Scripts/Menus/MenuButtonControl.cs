using System.Collections;
using FG_Saving;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonControl : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject newGameMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject exitMenu;
    [SerializeField] private GameObject loadMenu;
    private GameObject curMenu;

    public TMP_Text resetWarningText;
    
    private int saveFilesCount = 0;


    private void Start()
    {
        settingsMenu.SetActive(false);
        newGameMenu.SetActive(false);
        exitMenu.SetActive(false);
        loadMenu.SetActive(false);
        mainMenu.SetActive(true);
        resetWarningText.gameObject.SetActive(false);
      
        curMenu = mainMenu;
    }
    
    public void NewGame()
    {
        curMenu.SetActive(false);
        newGameMenu.SetActive(true);
        curMenu = newGameMenu;
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

    
    
    public void LoadGame()
    {
        curMenu.SetActive(false);
        loadMenu.SetActive(true);
        curMenu = loadMenu;
    }

    public void Continue()
    {
        saveFilesCount = PlayerPrefs.GetInt("SaveFilesCount");
        if (saveFilesCount > 0)
        {
            AutoLoad.Enabled = true;
            SceneManager.LoadScene("Game");
        }
        else
        {
            print("error, no save file found");
        }
    }

    public void ResetSettings()
    { 
        PlayerPrefs.DeleteAll();
    }

    public void ShowWarning()
    {
        resetWarningText.gameObject.SetActive(true);
    }
    
    public void HideWarning()
    {
        resetWarningText.gameObject.SetActive(false);
    }

}
