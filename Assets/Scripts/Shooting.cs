using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public InventoryManager inventoryManager;
    public HotBarInventory hotBarInventory;
    private float time;
    private float eatTime;
    private float nextTimeToFire = 0;
    private PlayerHealth playerHealth;
    public ReloadSlider reloadSlider;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Update()
    {
        time += Time.deltaTime;
        eatTime += Time.deltaTime;
        // Reload slider
        if (time < nextTimeToFire)
        {
            reloadSlider.gameObject.SetActive(true);
            reloadSlider.SliderUpdate(time, nextTimeToFire);
        }
        else
        {
            reloadSlider.gameObject.SetActive(false);
        }
        // Item usage
        if (Input.GetButton("Fire1") && time >= nextTimeToFire)
        {
            if (inventoryManager.isOpened == false)
            {
                if (hotBarInventory.activeSlot != null)
                {
                    if (hotBarInventory.activeSlot.item != null)
                    {
                        var item = hotBarInventory.activeSlot.item;
                        if (item.itemType == ItemType.Weapon)
                        {
                            nextTimeToFire = 1 / item.fireRate;
                            Shoot(item.bulletPrefab, item.bulletSpeed, item.damage, item.range);
                        }
                        else if (item.itemType == ItemType.Food && eatTime > 2f)
                        {
                            playerHealth.ChangeHealth(item.heal);
                            hotBarInventory.activeSlot.amount -= 1;
                            hotBarInventory.activeSlot.transform.GetChild(0).transform.GetChild(1).GetComponent<TMP_Text>().text = hotBarInventory.activeSlot.amount.ToString();
                            eatTime = 0;
                            if (hotBarInventory.activeSlot.amount <= 0)
                            {
                                hotBarInventory.activeSlot.gameObject.GetComponentInChildren<DragAndDropItem>().NullifySlotData();
                                hotBarInventory.activeSlotUpdate();
                            }
                        }
                    }
                    
                }

            }
        }
    }

    void Shoot(GameObject bulletPrefab, float bulletForce, float damage, float lifetime)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        bullet.GetComponent<Bullet>().damage = damage;
        bullet.GetComponent<Bullet>().lifetime = lifetime;
        time = 0;
    }
}
