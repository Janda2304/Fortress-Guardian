using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityChange : MonoBehaviour
{
    public Slider sensitivitySlider;


    private void Start()
    {
        sensitivitySlider.value = PlayerPrefs.GetFloat("MouseSensitivity");
        MouseLook.mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
    }

    public void ChangeMouseSensitivity()
    {
       MouseLook.mouseSensitivity  = sensitivitySlider.value;
       PlayerPrefs.SetFloat("MouseSensitivity", MouseLook.mouseSensitivity);

    }
}
