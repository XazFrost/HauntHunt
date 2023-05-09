using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicSettings : MonoBehaviour
{
    public GameObject low, normal, high;

    public void SetQualityLow()
    {
        SetQuality(0);
        low.GetComponent<Button>().interactable = false;
        normal.GetComponent<Button>().interactable = true;
        high.GetComponent<Button>().interactable = true;
    }

        public void SetQualityMedium()
    {
        SetQuality(1);
        low.GetComponent<Button>().interactable = true;
        normal.GetComponent<Button>().interactable = false;
        high.GetComponent<Button>().interactable = true;
    }

        public void SetQualityHigh()
    {
        SetQuality(2);
        low.GetComponent<Button>().interactable = true;
        normal.GetComponent<Button>().interactable = true;
        high.GetComponent<Button>().interactable = false;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        string[] names = QualitySettings.names;
        Debug.Log(names[QualitySettings.GetQualityLevel()]);
    }
}
