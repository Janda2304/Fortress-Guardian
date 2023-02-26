using System;
using System.Collections;
using System.Collections.Generic;
using FG_Saving;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameMenu : MonoBehaviour
{
    private int saveFilesCount;
    [SerializeField] private TMP_Text warningText;
    public int curSaveFile;


    private void Start()
    {
        warningText.gameObject.SetActive(false);
        saveFilesCount = PlayerPrefs.GetInt("SaveFilesCount");
        curSaveFile = PlayerPrefs.GetInt("SaveFile");
    }

    public void StartGame()
    {
        saveFilesCount = PlayerPrefs.GetInt("SaveFilesCount");
        saveFilesCount += 1;
        
        SaveManage.saveFile += 1;
        curSaveFile = SaveManage.saveFile;
        if (saveFilesCount >= 3)
        {
            saveFilesCount = 3;
        }
        if (SaveManage.saveFile > 3)
        {
            SaveManage.saveFile = curSaveFile;
        }
        PlayerPrefs.SetInt("SaveFile", SaveManage.saveFile);
        print(saveFilesCount);
        PlayerPrefs.SetInt("SaveFilesCount", saveFilesCount);
        AutoLoad.Enabled = false;
        SceneManager.LoadScene("Game");
        
        
        
    }
    
    public void ShowWarning()
    {
        if (saveFilesCount >= 3)
        {
            warningText.gameObject.SetActive(true);
        }
     
    }
    
    public void HideWarning()
    {
        warningText.gameObject.SetActive(false);
    }
}
