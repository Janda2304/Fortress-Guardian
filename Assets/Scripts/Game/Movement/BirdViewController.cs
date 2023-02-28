using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BirdViewController : MonoBehaviour
{
   [SerializeField] private CharacterController character;
   [SerializeField] private Camera birdCamera;
   [SerializeField] private AudioListener birdListener;
   [SerializeField] private GameObject player;
   [SerializeField] private float speed;
   [SerializeField] private float zoomSpeed;
   private bool isBirdView;


   private void Start()
   {
       isBirdView = false;
       birdCamera.enabled = false;
       birdListener.enabled = false;
       player.SetActive(true);
   }

   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.F5) && !isBirdView)
       {
           isBirdView = true;
           player.SetActive(false);
           birdCamera.enabled = true;
           birdListener.enabled = true;
       
       }
       else if (Input.GetKeyDown(KeyCode.F5) && isBirdView)
       {
           isBirdView = false;
           player.SetActive(true);
           birdCamera.enabled = false;
           birdListener.enabled = false;
         
       }
     
   }

   private void FixedUpdate()
   {
      Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
      character.Move(move * (speed * Time.deltaTime));
      
      //a function for a zooming in and out by pressing Q and E
        if (Input.GetKey(KeyCode.Q))
        {
             birdCamera.fieldOfView = Mathf.Lerp(birdCamera.fieldOfView, 10, Time.deltaTime * zoomSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
             birdCamera.fieldOfView = Mathf.Lerp(birdCamera.fieldOfView, 100, Time.deltaTime * zoomSpeed);
        }
     




      /* var direction = Vector3.zero;
 
 
       float x = Input.GetAxisRaw("Horizontal");
       float z = Input.GetAxisRaw("Vertical");
 
 
 
       direction = transform.right * x + transform.forward * z;
       
       character.Move(direction * (speed * Time.deltaTime));*/
      
       
   }
   
}
