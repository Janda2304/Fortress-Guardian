using System;
using TMPro;
using UnityEngine;

public class FrameRateController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    private int[] frameRates = {30, 60, 75, 120, 144, 240, Int32.MaxValue};
    private int index;
    
    private void Start()
    {
        LoadFrameRate();
        index = Array.IndexOf(frameRates, Application.targetFrameRate);
        dropdown.value = index;
        dropdown.onValueChanged.AddListener(ChangeFrameRate);
    }

    private void ChangeFrameRate(int value)
    {
        index = value;
        Application.targetFrameRate = frameRates[index];
        PlayerPrefs.SetInt("FrameRate", frameRates[index]);
    }
    
    private void LoadFrameRate()
    {
        if (PlayerPrefs.HasKey("FrameRate"))
        {
            Application.targetFrameRate = PlayerPrefs.GetInt("FrameRate");
            index = Array.IndexOf(frameRates, Application.targetFrameRate);
            dropdown.value = index;
        }
    }
}
