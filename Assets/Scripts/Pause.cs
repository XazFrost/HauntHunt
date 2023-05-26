using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject optionsPanel;
    public bool isPaused = false;
    private bool isOptionsOpened = false;
    private GameObject hotbar;

    void Start()
    {
        hotbar = GameObject.FindGameObjectWithTag("HotBar");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameObject.GetComponent<InventoryManager>().isOpened == false)
        {
            PauseToggle();
        }
    }

    public void PauseToggle()
    {
        if (isOptionsOpened == false)
        {
            Time.timeScale = (isPaused? 1f : 0f);
            pausePanel.SetActive(isPaused? false : true);
            hotbar.SetActive(isPaused? true : false);
            isPaused = !isPaused;
        }
        else
        {
            OptionsClose();
        }
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void OptionsOpen()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(true);
        isOptionsOpened = true;
    }

    public void OptionsClose()
    {
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);
        isOptionsOpened = false;
    }
}
