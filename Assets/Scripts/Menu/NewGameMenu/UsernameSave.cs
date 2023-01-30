using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UsernameSave : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInputField;


   

    public void SaveUsername()
    {
        PlayerPrefs.SetString("Username", usernameInputField.text);
    }
    
    
}
