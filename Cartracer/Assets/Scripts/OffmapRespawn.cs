using System;
using UnityEngine;

public class OffmapRespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponentInParent<MultiplayerCarController>().Respawn();
    }
}
