using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTogglesControl : MonoBehaviour
{
   [SerializeField] private Toggle hintToggle;
   private bool isOn;
   
   
   private void Start()
   {
      
           
      
   }

   public void ToggleHints()
   {
       if (!hintToggle.isOn)
       {
           PlayerPrefs.SetBool("Hints", false);
       }
       else
       {
           PlayerPrefs.SetBool("Hints", true);
       }
       
   }

   public void ResetTutorial()
   {
       PlayerPrefs.DeleteKey("ReturningPlayer");
   }
   
}
