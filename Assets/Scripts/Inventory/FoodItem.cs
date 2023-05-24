using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food Item", menuName = "Item/New Food Item")]
public class FoodItem : ItemScriptableObject
{
    private void Start()
    {
        itemType = ItemType.Food; 
    }
}
