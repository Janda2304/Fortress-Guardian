using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityChange : MonoBehaviour
{
    public Slider sensitivitySlider;
    public void ChangeMouseSensitivity()
    {
       MouseLook.mouseSensitivity  = sensitivitySlider.value;
       PlayerPrefs.SetFloat("MouseSensitivity", MouseLook.mouseSensitivity);

    }
}
