using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public int killCounter = 0; // variable to store the kill count

    private void Start()
    {
        // Initialize the kill count at the start of the game
        killCounter = 0;

    }

    // Method to increase the kill count
    public void IncreaseKillCount()
    {
        killCounter++;
        Debug.Log("Kill count: " + killCounter);
    }

    // Method to handle ghost death
    public void HandleGhostDeath()
    {

        GameManager.Instance.IncreaseKillCount();
        // Increase the kill count
        IncreaseKillCount();
    }
}
