using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// show message on UI - maybe particle effect (confetti, fireworks?)
// change game state - GameManager

// Track checkpoints -- only allow win after crossing all checkpoints

public class CrossFinishLine : MonoBehaviour
{
    public int numberOfLapsToWin = 3;
    public GameObject checkpointParent;
    [HideInInspector] public Transform lastCheckpoint;
    private GameObject[] checkpoints;
    private int playerNumber;

    private int lapCounter = 1;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI lapCounterText;
    public ParticleSystem confetti;
    private void Start()
    {
        playerNumber = GetComponent<MultiplayerCarController>().playerNumber;
        FillCheckpointArray();
        UpdateLapCounter();
    }

    private void UpdateLapCounter()
    {
        lapCounterText.text = "Lap " + lapCounter;
    }

    private void FillCheckpointArray()
    {
        List<GameObject> children = new List<GameObject>();

        foreach (Transform child in checkpointParent.transform)
        {
            children.Add(child.gameObject);
        }

        checkpoints = children.ToArray();
    }

    private bool AllCheckpointsCrossed()
    {
        foreach (GameObject checkpoint in checkpoints)
        {
            Checkpoint checkpointScript = checkpoint.GetComponent<Checkpoint>();
            if (playerNumber == 1)
            {
                if (checkpointScript != null && !checkpointScript.hasPlayer1Crossed)
                {
                    return false;
                }
            }
            if (playerNumber == 2)
            {
                if (checkpointScript != null && !checkpointScript.hasPlayer2Crossed)
                {
                    return false;
                }
            }
        }
        return true;
    }
    
    private void ResetCheckpoints()
    {
        foreach (GameObject checkpoint in checkpoints)
        {
            Checkpoint checkpointScript = checkpoint.GetComponent<Checkpoint>();
            if (checkpointScript)
            {
                if (playerNumber == 1)
                    checkpointScript.hasPlayer1Crossed = false;
                else if (playerNumber == 2)
                    checkpointScript.hasPlayer1Crossed = false;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine") && AllCheckpointsCrossed())
        {
            lapCounter++;
            UpdateLapCounter();
            if (lapCounter > numberOfLapsToWin)
            {
                ShowWinCondition();
            }
            else ResetCheckpoints();
        }
    }

    void ShowWinCondition()
    {
        winText.gameObject.SetActive(true);
        winText.text = "Player " + playerNumber + " wins!";
    }
}
