using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultyControl : MonoBehaviour
{
   [SerializeField] private TMP_Text _difficultyText;
   public static string difficulty = "Novice";
   public string[] difficulties = new []{"Novice", "Journeyman", "Master"};
   private int index;
        
   void Start()
   { 
      LoadDifficulty();
      
   }
   
   #region Difficulty Change Functions
   public void ChangeDifficulty()
   {
      index++;
      index = ClampNumber(index, 0, 2);
      difficulty = difficulties[index];
      _difficultyText.text = difficulty;
      PlayerPrefs.SetString("difficulty", difficulty);
   }
   
   public void ChangeDifficultyBack()
   {
      index--;
      index = ClampNumber(index, 0, 2);
      difficulty = difficulties[index];
      _difficultyText.text = difficulty;
      PlayerPrefs.SetString("difficulty", difficulty);
   }
   #endregion Difficulty Change Functions
   
   public void LoadDifficulty()
   {
      if (PlayerPrefs.HasKey("difficulty"))
      {
         difficulty = PlayerPrefs.GetString("difficulty");
         _difficultyText.text = difficulty;
      }
      else
      {
         difficulty = "Novice";
         _difficultyText.text = difficulty;
         PlayerPrefs.SetString("difficulty", difficulty);
      }
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
   
   
   
}
