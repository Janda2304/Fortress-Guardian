using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPopup : MonoBehaviour
{
   [SerializeField] private GameObject popup;
   [SerializeField] private GameObject building;
   [SerializeField] private GameObject player;
   [SerializeField] private float popupDistance = 3f;
   private Camera cam;

   private void Start()
   {
       cam = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>();
       popup.SetActive(false);
       player = GameObject.FindGameObjectWithTag("Player");
   }

   void Update()
    {
        if (Vector3.Distance(building.transform.position, player.transform.position) < popupDistance)
        {
            popup.SetActive(true);
            popup.transform.LookAt(cam.transform);
        }
        else
        {
            popup.SetActive(false);
        }
    }
}
