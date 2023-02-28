using System;
using System.Collections;
using System.Collections.Generic;
using FG_Saving;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenuControl : MonoBehaviour
{
    [SerializeField] private TMP_Text sav1Text;
    [SerializeField] private TMP_Text sav2Text;
    [SerializeField] private TMP_Text sav3Text;
    private List<int> saveFiles = new List<int>();
    
    private void Start()
    {
        sav1Text.text = "Save 1: Empty";
        sav2Text.text = "Save 2: Empty";
        sav3Text.text = "Save 3: Empty";
        switch (PlayerPrefs.GetInt("SaveFilesCount"))
        {
            case 1:
                saveFiles.Add(1);
                break;
            case 2:
                saveFiles.Add(1);
                saveFiles.Add(2);
                break;
            case 3:
                saveFiles.Add(1);
                saveFiles.Add(2);
                saveFiles.Add(3);
                break;
            
        }

        for (int i = 0; i < saveFiles.Count; i++) 
        {
            if (i == 0) {
                sav1Text.text = "Save: " + saveFiles[i];
                sav1Text.GetComponent<Button>().enabled = true;
            } else if (i == 1) {
                sav2Text.text = "Save: " + saveFiles[i];
                sav2Text.GetComponent<Button>().enabled = true;
            } else if (i == 2) {
                sav3Text.text = "Save: " + saveFiles[i];
                sav3Text.GetComponent<Button>().enabled = true;
            }
        }
        
        if (saveFiles.Count == 1 )
        {
            sav1Text.text = "Save: " + saveFiles[0];
            sav1Text.GetComponent<Button>().onClick.AddListener(() => LoadGame(saveFiles[0]));
            sav2Text.text = "Save 2: Empty";
            sav3Text.text = "Save 3: Empty";
        }
        
        if (saveFiles.Count == 2 )
        {
            sav1Text.text = "Save: " + saveFiles[0];
            sav1Text.GetComponent<Button>().onClick.AddListener(() => LoadGame(saveFiles[0]));
            
            sav2Text.text = "Save: " + saveFiles[1];
            sav2Text.GetComponent<Button>().onClick.AddListener(() => LoadGame(saveFiles[1]));
            
            sav3Text.text = "Save 3: Empty";
        }
        
        if (saveFiles.Count == 3 )
        {
            sav1Text.text = "Save: " + saveFiles[0];
            sav1Text.GetComponent<Button>().onClick.AddListener(() => LoadGame(saveFiles[0]));
            
            sav2Text.text = "Save: " + saveFiles[1];
            sav2Text.GetComponent<Button>().onClick.AddListener(() => LoadGame(saveFiles[1]));
            
            sav3Text.text = "Save: " + saveFiles[2];
            sav2Text.GetComponent<Button>().onClick.AddListener(() => LoadGame(saveFiles[2]));
        }
        
        
        
       
    }
    
    public void LoadGame(int saveFile)
    {
        PlayerPrefs.SetInt("SaveFile", saveFile);
        SaveManage.saveFile = saveFile;
        AutoLoad.Enabled = true;
        SceneManager.LoadScene("Game");
    }
}
