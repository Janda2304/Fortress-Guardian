using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityChange : MonoBehaviour
{
    public Slider mouseXSlider;
    public Slider mouseYSlider;
    public Slider masterSlider;


    private void Start()
    {
        mouseXSlider.value = PlayerPrefs.GetFloat("MouseX");
        mouseYSlider.value = PlayerPrefs.GetFloat("MouseX");
        masterSlider.value = PlayerPrefs.GetFloat("MouseX");
        MouseLook.mouseXSensitivity = PlayerPrefs.GetFloat("MouseX");
        MouseLook.mouseYSensitivity = PlayerPrefs.GetFloat("MouseY");
    }

    public void ChangeMouseX()
    {
       MouseLook.mouseXSensitivity  = mouseXSlider.value;
       PlayerPrefs.SetFloat("MouseX", MouseLook.mouseXSensitivity);

    }
    
    public void ChangeMouseY()
    {
        MouseLook.mouseYSensitivity  = mouseYSlider.value;
        PlayerPrefs.SetFloat("MouseY", MouseLook.mouseYSensitivity);

    }

    public void ChangeMouseSensitivity()
    {
        MouseLook.mouseXSensitivity = masterSlider.value;
        MouseLook.mouseYSensitivity = masterSlider.value;
        mouseXSlider.value = masterSlider.value;
        mouseYSlider.value = masterSlider.value;
        PlayerPrefs.SetFloat("MouseX", MouseLook.mouseXSensitivity);
        PlayerPrefs.SetFloat("MouseY", MouseLook.mouseYSensitivity);
        
    }
}
