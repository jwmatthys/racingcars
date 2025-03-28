using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    ArcadeCarController carController;

    private void Start()
    {
        carController = GetComponent<ArcadeCarController>();
    }

    public void OnSteer(InputAction.CallbackContext context)
    {
        float steering = context.ReadValue<float>();
        carController.steeringInput = steering;
    }

    public void OnAccelerate(InputAction.CallbackContext context)
    {
        if (context.performed) carController.forceInput = 1;
        else if (context.canceled) carController.forceInput = 0;
    }

    public void OnReverse(InputAction.CallbackContext context)
    {
        if (context.performed) carController.forceInput = -1;
        else if (context.canceled) carController.forceInput = 0;
    }
}
