using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfos : MonoBehaviour
{
   [SerializeField] private List<TowerInfo> towers = new List<TowerInfo>();

   private void Start()
   {
       
   }
}


[System.Serializable]

public class TowerInfo
{
    public string name;
    public int cost;
    public int health;
    public int damage;
    public float range;
    public float fireRate;
    public float RotationSpeed;


    public void SetInfo()
    {
        
    }
    
    
    
}
