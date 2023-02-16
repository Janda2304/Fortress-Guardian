using System;
using TMPro;
using UnityEngine;

public class FrameRateController : MonoBehaviour
{
    [SerializeField] private TMP_Text fpsText;
    private int frameRate;
    private int index;
    private int[] frameRates = {60, 75, 120, 144 };
    private int min = 0;
    private int max = 3;

    private string username;

    private void Start()
    {
        LoadFps();
        username = PlayerPrefs.GetString("Username");
        if (username is "aleš" or "ales" or "aski" or "aski_98" or "aski_94" or "aski94" or "aski98")
        {
            frameRates = new int[] { 60, 75, 120, 144, Int32.MaxValue };
            max = 4;
        }
      
        
    }

    public void ChangeFPS()
    {
        index++;
        index = ClampNumber(index, min, max);
        frameRate = frameRates[index];
        Application.targetFrameRate = frameRate;
        if (frameRate == Int32.MaxValue)
        {
            fpsText.text = "Unlimited";
        }
        else if (frameRate != Int32.MaxValue)
        {
            fpsText.text =  frameRate.ToString();
        
        }
        PlayerPrefs.SetInt("FrameRate", frameRate);
    }


    public void ChangeFPSBack()
    {
        index--;
        index = ClampNumber(index, min, max);
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
