using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Item", menuName = "Item/New Weapon Item")]
public class WeaponItem : ItemScriptableObject
{
    private void Start()
    {
        itemType = ItemType.Weapon; 
    }
}
