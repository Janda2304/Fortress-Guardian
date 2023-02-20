using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FG_Graphics
{ 
    public class GraphicsSettings : MonoBehaviour 
    {
    [Header("Post Processing")]
    [SerializeField] private PostProcessVolume postProcess;
    [SerializeField] private Toggle bloomToggle;
    [SerializeField] private Toggle ambientOcclusionToggle;
    [SerializeField] private Toggle motionBlurToggle;
    [SerializeField] private Toggle vignetteToggle;
    [Header("Resolution/FrameRate")]
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown fpsDropdown;
    private int[] frameRates = {30, 60, 75, 120, 144, 240, Int32.MaxValue};
    private int fpsIndex;
    #region Resolution
    private int[] resolutionsWidth = {3840, 2560, 1920, 1680, 1600, 1440, 1366, 1280, 800};
    private int[] resolutionsHeight = {2160, 1440, 1080, 1050, 900, 900, 768, 720, 600};
    private int heightIndex;
    private int widthIndex;
    #endregion

        private void Start()
        {
            LoadBloom();
            LoadAmbientOcclusion();
            LoadMotionBlur();
            LoadVignette();
            LoadResolution();
            LoadFrameRate();
            widthIndex = Array.IndexOf(resolutionsWidth, Screen.width);
            heightIndex = Array.IndexOf(resolutionsHeight, Screen.height);
            resolutionDropdown.value = widthIndex;
            resolutionDropdown.onValueChanged.AddListener(ChangeResolution);
           
            fpsIndex = Array.IndexOf(frameRates, Application.targetFrameRate);
            fpsDropdown.value = fpsIndex;
            fpsDropdown.onValueChanged.AddListener(ChangeFrameRate);
        }

        #region Toggles
        public void ToggleBloom()
        {
            postProcess.profile.TryGetSettings(out Bloom bloom);
            if (!bloomToggle.isOn)
            {

                bloom.enabled.value = false;
                PlayerPrefs.SetBool("Bloom", false);
              
            }
            else
            {
                bloom.enabled.value = true;
                PlayerPrefs.SetBool("Bloom", true);
             
            }

        }
        
        public void ToggleAmbientOcclusion()
        {
            postProcess.profile.TryGetSettings(out AmbientOcclusion ambientOcclusion);
            if (!ambientOcclusionToggle.isOn)
            {
                ambientOcclusion.enabled.value = false;
                PlayerPrefs.SetBool("AmbientOcclusion", false);
                
            }
            else
            {
                ambientOcclusion.enabled.value = true;
                PlayerPrefs.SetBool("AmbientOcclusion", true);
            }
        }
        
        public void ToggleMotionBlur()
        {
            postProcess.profile.TryGetSettings(out MotionBlur motionBlur);
            if (!motionBlurToggle.isOn)
            {
                motionBlur.enabled.value = false;
                PlayerPrefs.SetBool("MotionBlur", false);
                
            }
            else
            {
                motionBlur.enabled.value = true;
                PlayerPrefs.SetBool("MotionBlur", true);
            }
        }
        
        public void ToggleVignette()
        {
            postProcess.profile.TryGetSettings(out Vignette vignette);
            if (!vignetteToggle.isOn)
            {
                vignette.enabled.value = false;
                PlayerPrefs.SetBool("Vignette", false);
                
            }
            else
            {
                vignette.enabled.value = true;
                PlayerPrefs.SetBool("Vignette", true);
            }
        }
        #endregion
        
        private void ChangeResolution(int value)
        {
            widthIndex = value;
            heightIndex = value;
            Screen.SetResolution(resolutionsWidth[widthIndex], resolutionsHeight[heightIndex], Screen.fullScreen);
            PlayerPrefs.SetInt("ResolutionWidth", resolutionsWidth[widthIndex]);
            PlayerPrefs.SetInt("ResolutionHeight", resolutionsHeight[heightIndex]);
            
        }
        
        private void ChangeFrameRate(int value)
        {
            fpsIndex = value;
            Application.targetFrameRate = frameRates[fpsIndex];
            PlayerPrefs.SetInt("FrameRate", frameRates[fpsIndex]);
        }
    
     
        
        #region LoadSettings
        
        private void LoadFrameRate()
        {
            if (PlayerPrefs.HasKey("FrameRate"))
            {
                Application.targetFrameRate = PlayerPrefs.GetInt("FrameRate");
                fpsIndex = Array.IndexOf(frameRates, Application.targetFrameRate);
                fpsDropdown.value = fpsIndex;
            }
        }
        private void LoadResolution()
        {
            if (PlayerPrefs.HasKey("ResolutionWidth") && PlayerPrefs.HasKey("ResolutionHeight"))
            {
                Screen.SetResolution(PlayerPrefs.GetInt("ResolutionWidth"), PlayerPrefs.GetInt("ResolutionHeight"), Screen.fullScreen);
                widthIndex= Array.IndexOf(resolutionsWidth, Screen.width);
                resolutionDropdown.value = widthIndex;
               
            }
            else
            {
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, Screen.fullScreen);
                widthIndex= Array.IndexOf(resolutionsWidth, Screen.width);
                resolutionDropdown.value = widthIndex;
                PlayerPrefs.SetInt("ResolutionWidth", Screen.width);
                PlayerPrefs.SetInt("ResolutionHeight", Screen.height);
                
            }
        }
        private void LoadBloom()
        {
            if (!PlayerPrefs.HasKey("Bloom"))
            {
                PlayerPrefs.GetBool("Bloom", false);
                postProcess.profile.GetSetting<Bloom>().enabled.value = false;
            }
            else
            {
                bloomToggle.isOn = PlayerPrefs.GetBool("Bloom");
                postProcess.profile.GetSetting<Bloom>().enabled.value = bloomToggle.isOn;
                
            }
        }
        
        private void LoadAmbientOcclusion()
        {
            if (!PlayerPrefs.HasKey("AmbientOcclusion"))
            {
                PlayerPrefs.GetBool("AmbientOcclusion", false);
                postProcess.profile.GetSetting<AmbientOcclusion>().enabled.value = false;
            }
            else
            {
                ambientOcclusionToggle.isOn = PlayerPrefs.GetBool("AmbientOcclusion");
                postProcess.profile.GetSetting<AmbientOcclusion>().enabled.value = ambientOcclusionToggle.isOn;
            }
        }
        
        private void LoadMotionBlur()
        {
            if (!PlayerPrefs.HasKey("MotionBlur"))
            {
                PlayerPrefs.GetBool("MotionBlur", false);
                postProcess.profile.GetSetting<MotionBlur>().enabled.value = false;
            }
            else
            {
                motionBlurToggle.isOn = PlayerPrefs.GetBool("MotionBlur");
                postProcess.profile.GetSetting<MotionBlur>().enabled.value = motionBlurToggle.isOn;
            }
        }
        
        private void LoadVignette()
        {
            if (!PlayerPrefs.HasKey("Vignette"))
            {
                PlayerPrefs.GetBool("Vignette", false);
                postProcess.profile.GetSetting<Vignette>().enabled.value = false;
            }
            else
            {
                vignetteToggle.isOn = PlayerPrefs.GetBool("Vignette");
                postProcess.profile.GetSetting<Vignette>().enabled.value = vignetteToggle.isOn;
            }
        }
        #endregion

}
}


