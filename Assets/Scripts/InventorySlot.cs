using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemScriptableObject item;
    public int amount;
    public bool isEmpty = true;

    public GameObject IconGO;
    public TMP_Text itemAmountText;

    private void Awake()
    {
        IconGO = transform.GetChild(0).gameObject;
        itemAmountText = transform.GetChild(1).GetComponent<TMP_Text>();
    }

    public void SetIcon(Sprite icon)
    {
        IconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        IconGO.GetComponent<Image>().sprite = icon;
    }
}
