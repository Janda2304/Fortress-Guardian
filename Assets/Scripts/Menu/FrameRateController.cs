using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrameRateController : MonoBehaviour
{
    [SerializeField] private TMP_Text fpsText;
    private int frameRate;
    private int index;
    private int[] frameRates = {60, 75, 120, 144 };

    private void Start()
    {
        LoadFps();
    }

    public void ChangeFPS()
    {
        index++;
        index = ClampNumber(index, 0, 3);
        frameRate = frameRates[index];
        Application.targetFrameRate = frameRate;
        fpsText.text = frameRate.ToString();
        PlayerPrefs.SetInt("FrameRate", frameRate);
    }


    public void ChangeFPSBack()
    {
        index--;
        index = ClampNumber(index, 0, 3);
        frameRate = frameRates[index];
        Application.targetFrameRate = frameRate;
        fpsText.text = frameRate.ToString();
        PlayerPrefs.SetInt("FrameRate", frameRate);
    }
    
    
    private int ClampNumber(int value, int min, int max)
    {
        if (value > max)
        {
            value = min;
        }
        else if (value < min)
        {
            value = max;
        }
      
        return value;
    }

    private void LoadFps()
    {
        if (!PlayerPrefs.HasKey("FrameRate"))
        {
            frameRate = PlayerPrefs.GetInt("FrameRate", 60);
            Application.targetFrameRate = frameRate;
            fpsText.text = frameRate.ToString();
        }
        else
        {
            frameRate = PlayerPrefs.GetInt("FrameRate");
            Application.targetFrameRate = frameRate;
            fpsText.text = frameRate.ToString();
        }
    }
    
}
