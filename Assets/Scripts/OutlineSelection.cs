using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    private Transform highlight;
    private RaycastHit raycastHit;
    private GameObject player;
    public InventoryManager inventoryManager;
    public Color outlineColorNear = Color.green;
    public Color outlineColorFar = Color.red;
    public float outlineWidth = 5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable"))
            {
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.OutlineWidth = outlineWidth;
                    outline.enabled = true;
                }
                //Check distance
                var range = Vector3.Distance(highlight.position, player.transform.position);
                if (range <= inventoryManager.pickupRange)
                {
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = outlineColorNear;
                }
                else
                {
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = outlineColorFar;
                }
                highlight.gameObject.GetComponent<Outline>().UpdateMaterialProperties();
            }
            else
            {
                highlight = null;
            }
        }
    }
}
