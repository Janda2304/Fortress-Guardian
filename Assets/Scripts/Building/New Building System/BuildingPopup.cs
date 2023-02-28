using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FG_NewBuildingSystem
{


    public class BuildingPopup : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;

        private void Start()
        {
            canvas.worldCamera = FindObjectOfType<Camera>();
        }
       public void Upgrade()
       {
           print("Upgrade");
       }
    }
}