using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction touchPositionAction;

    private const string TOUCH_POSITION_ACTION = "TouchPosition";
    
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPositionAction = playerInput.actions.FindAction(TOUCH_POSITION_ACTION);
        
    }

    private void OnEnable()
    {
        touchPositionAction.performed += TouchPressed;
    }


    private void TouchPressed(InputAction.CallbackContext context)
    {
        
        Vector3 selectPosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        selectPosition.z = 0;

        OnTouchPositionGet?.Invoke(this, new OnTouchPositionGetEventArgs() { touchPositionVector3 = selectPosition });
        
        
    }

    public event EventHandler<OnTouchPositionGetEventArgs> OnTouchPositionGet;
    public class OnTouchPositionGetEventArgs: EventArgs
    {
        public Vector3 touchPositionVector3;
    }
    
}

   
