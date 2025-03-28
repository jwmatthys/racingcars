using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    ArcadeCarController carController;
    PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        int index = playerInput.playerIndex;
        var controllers = FindObjectsByType<ArcadeCarController>(FindObjectsSortMode.None);
        carController = controllers.FirstOrDefault(c => c.GetPlayerIndex() == index);
    }

    public void OnSteer(InputAction.CallbackContext context)
    {
        if (carController != null)
        {
            float steering = context.ReadValue<float>();
            carController.steeringInput = steering;
        }
    }

    public void OnAccelerate(InputAction.CallbackContext context)
    {
        if (carController != null)
        {
            if (context.performed) carController.forceInput = 1;
            else if (context.canceled) carController.forceInput = 0;
        }
    }

    public void OnReverse(InputAction.CallbackContext context)
    {
        if (carController != null)
        {
            if (context.performed) carController.forceInput = -1;
            else if (context.canceled) carController.forceInput = 0;
        }
    }
}
