using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIPanel;
    public Transform inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpened;
    private Camera mainCamera;
    public float reachDistance = 20f;

    private void Awake()
    {
        UIPanel.SetActive(true);
    }

    void Start()
    {
        mainCamera = Camera.main;

        // Slots from hot bar
        Transform hotBarPanel = GameObject.FindGameObjectWithTag("HotBar").transform;

        for (int i = 0; i < hotBarPanel.childCount; i++)
        {
            if (hotBarPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(hotBarPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }

        // Slots from inventory panel
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }

        UIPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Inventory opening
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpened = !isOpened;
            UIPanel.SetActive(isOpened ? true : false);
        }

        // Item PickUp
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit, reachDistance))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                    Destroy(hit.collider.gameObject);
                    GameObject.FindGameObjectWithTag("HotBar").GetComponent<HotBarInventory>().activeSlotUpdate();
                }
                Debug.DrawRay(ray.origin, ray.direction*reachDistance, Color.blue);
            }
        }
    }

    private void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach(InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                if (slot.amount + _amount <= _item.maximumAmount)
                {
                    slot.amount += _amount;
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;
                }
                break;
            }

        }
        foreach(InventorySlot slot in slots)
        {
            if (slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.itemAmountText.text = _amount.ToString();
                break;
            }
            
        }
    }
}
