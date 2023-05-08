using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }

    public void Options(GameObject window)
    {
        window.SetActive(true);
    }
}
