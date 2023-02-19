using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsOverlayControl : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsOverlay;
    [SerializeField] private GameObject mainSettings;
    [SerializeField] private GameObject graphicsSettings;
    [SerializeField] private GameObject audioSettings;
    [SerializeField] private GameObject controlsSettings;
    private GameObject curScreen;
    
    
    
    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsOverlay.SetActive(true);
        mainSettings.SetActive(true);
        graphicsSettings.SetActive(false);
        audioSettings.SetActive(false);
        controlsSettings.SetActive(false);
        curScreen = mainSettings;
    }
    
    
    public void CloseSettings()
    {
        settingsOverlay.SetActive(false);
        curScreen.SetActive(false);
        mainMenu.SetActive(true);
    }
    
    
    public void OpenGraphics()
    {
        curScreen.SetActive(false);
        graphicsSettings.SetActive(true);
        curScreen = graphicsSettings;
    }
    
    public void OpenMain()
    {
        curScreen.SetActive(false);
        mainSettings.SetActive(true);
        curScreen = mainSettings;
    }
    
    public void OpenAudio()
    {
        curScreen.SetActive(false);
        audioSettings.SetActive(true);
        curScreen = audioSettings;
    }

    public void OpenControls()
    {
        curScreen.SetActive(false);
        controlsSettings.SetActive(true);
        curScreen = controlsSettings;
    }

}
