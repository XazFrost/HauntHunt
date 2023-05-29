using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject _descriptionPanel;
    private Image _img;
    private TMP_Text _name, _desc, _param1name, _param2name, _param1value, _param2value;
    public void DescInitiate()
    {
        _descriptionPanel = GameObject.FindGameObjectWithTag("ItemDescription");
        _img = _descriptionPanel.transform.Find("ItemIconImage").GetComponent<Image>();
        _name = _descriptionPanel.transform.Find("ItemNameText").GetComponent<TMP_Text>();
        _desc = _descriptionPanel.transform.Find("ItemDescText").GetComponent<TMP_Text>();
        _param1name = _descriptionPanel.transform.Find("Param1Name").GetComponent<TMP_Text>();
        _param2name = _descriptionPanel.transform.Find("Param2Name").GetComponent<TMP_Text>();
        _param1value = _descriptionPanel.transform.Find("Param1Value").GetComponent<TMP_Text>();
        _param2value = _descriptionPanel.transform.Find("Param2Value").GetComponent<TMP_Text>();

        Debug.Log(gameObject.name);

        ClearDescription();
    }
    public void OnPointerEnter(PointerEventData eventData)
	{
		if (transform.parent.GetComponent<InventorySlot>().item != null)
        {
            ItemScriptableObject item = transform.parent.GetComponent<InventorySlot>().item;
            _img.color = new Color(1f, 1f, 1f, 1f);
            _img.sprite = item.icon;
            _name.text = item.itemName;
            _desc.text = item.itemDescription;
            if (item.itemType == ItemType.Weapon)
            {
                _param1name.text = "Damage";
                _param1value.text = item.damage.ToString();
                _param2name.text = "Fire Rate";
                _param2value.text = item.fireRate.ToString();
            }
            else if (item.itemType == ItemType.Food)
            {
                _param1name.text = "Heal";
                _param1value.text = item.heal.ToString();
                _param2name.text = "Max Amount";
                _param2value.text = item.maximumAmount.ToString();
            }

            // Item highlight
            //transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
	}

	public void OnPointerExit(PointerEventData eventData)
	{
        if (transform.parent.GetComponent<InventorySlot>() != null)
        {
            if (transform.parent.GetComponent<InventorySlot>().item != null)
            {
                ClearDescription();
                //transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
            }
        }
	}

    void ClearDescription()
    {
        _img.color = new Color(1f, 1f, 1f, 0f);
        _name.text = "Item info";
        _desc.text = "point at any item slot";
        _param1name.text = null;
        _param1value.text = null;
        _param2name.text = null;
        _param2value.text = null;
    }
}
