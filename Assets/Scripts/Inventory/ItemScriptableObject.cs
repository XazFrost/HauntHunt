using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Default, Food, Weapon}

public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public GameObject itemPrefab;
    public Sprite icon;
    public int maximumAmount;
    public string itemDescription;
}
