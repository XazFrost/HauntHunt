using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("First_Level");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }

    public void Options(GameObject window)
    {
        window.SetActive(true);
    }

    public void NewGame(GameObject window)
    {
        window.SetActive(true);
    }
}
