using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool hasPlayer1Crossed;
    public bool hasPlayer2Crossed;


    private void OnTriggerEnter(Collider other)
    {
        MultiplayerCarController controller = other.gameObject.GetComponentInParent<MultiplayerCarController>();
        if (controller != null)
        {
            if (controller.playerNumber == 1) hasPlayer1Crossed = true;
            if (controller.playerNumber == 2) hasPlayer2Crossed = true;
            controller.SetNewCheckpoint(transform);
        }
    }
}
