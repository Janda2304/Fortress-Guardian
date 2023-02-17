using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
   private PlayerInputActions inputActions;
   [SerializeField] private PlayerInput playerInput;
   [SerializeField] private CharacterController controller;
   [SerializeField] private float speed = 12f;

   private void Awake()
   {
      inputActions = new PlayerInputActions();
      inputActions.Enable();
      inputActions.Player.RebindKey.performed += Rebind;
   }

   private void Update()
   {
      Vector2 inputVector = inputActions.Player.Movement.ReadValue<Vector2>();
      Vector3 move = new Vector3(inputVector.x, 0f, inputVector.y);
      controller.Move(move * (speed * Time.deltaTime));
   }

   private void Rebind(InputAction.CallbackContext context)
   {
      inputActions.Player.Disable();
      inputActions.Player.Message.PerformInteractiveRebinding().OnComplete(context =>
      {
         inputActions.Player.Enable();
         context.Dispose();
         print("rea");
      }).Start();
   }



}

