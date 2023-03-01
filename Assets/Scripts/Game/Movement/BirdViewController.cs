using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace FG_Movement
{
    public class BirdViewController : MonoBehaviour
    {
        [SerializeField] private CharacterController character;
        [SerializeField] private Camera birdCamera;
        [SerializeField] private AudioListener birdListener;
        [SerializeField] private GameObject player;
        [SerializeField] private float speed;
        [SerializeField] private float zoomSpeed;
        [SerializeField] private float zoomMin;
        [SerializeField] private float zoomMax;
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
            if (birdCamera.enabled)
            {
                Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                character.Move(move * (speed * Time.deltaTime));

                if (Input.GetKey(KeyCode.Q))
                {
                    birdCamera.fieldOfView = Mathf.Lerp(birdCamera.fieldOfView, zoomMin, Time.deltaTime * zoomSpeed);
                }

                if (Input.GetKey(KeyCode.E))
                {
                    birdCamera.fieldOfView = Mathf.Lerp(birdCamera.fieldOfView, zoomMax, Time.deltaTime * zoomSpeed);
                }
            }
           
        }
    }
}
