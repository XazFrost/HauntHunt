using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class KillCountDisplay : MonoBehaviour
{
    private KillCounter killCounter; // reference to the KillCounter script
    public TMP_Text killCountText; // reference to the Text component

    private void Start()
    {
        // Find the KillCounter component in the scene
        killCounter = FindObjectOfType<KillCounter>();

        // Get the Text component on this UI element
        killCountText = GetComponent<TMP_Text>();

        // Update the initial kill count on the UI element
        UpdateKillCount();
    }

    private void UpdateKillCount()
    {
        // Update the text to show the current kill count
        killCountText.text = killCounter.killCounter.ToString();
    }

    private void Update()
    {
        // Update the kill count text every frame
        UpdateKillCount();
    }
}
