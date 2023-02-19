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
       if (!PlayerPrefs.HasKey("hints"))
       {
           isOn = false;
           hintToggle.SetIsOnWithoutNotify(isOn);
        
       }
       else
       {
           if (PlayerPrefs.GetBool("hints") == false)
           {
               isOn = false;
               hintToggle.SetIsOnWithoutNotify(isOn);
           
           }
           else
           {
               isOn = true;
              hintToggle.SetIsOnWithoutNotify(isOn);
             
           }
        
       }
           
      
   }

   public void ToggleHints()
   {
       if (!isOn)
       {
           isOn = true;
           hintToggle.SetIsOnWithoutNotify(isOn);
       
           PlayerPrefs.SetBool("hints", isOn);
       }
       else
       {
           isOn = false;
           hintToggle.SetIsOnWithoutNotify(isOn);
           PlayerPrefs.SetBool("hints", isOn);
       }
   }

   public void ResetTutorial()
   {
       PlayerPrefs.DeleteKey("ReturningPlayer");
   }
   
}
