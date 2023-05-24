using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public InventoryManager inventoryManager;
    public HotBarInventory hotBarInventory;
    private float time;
    private float nextTimeToFire = 0;

    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetButton("Fire1") && time >= nextTimeToFire)
        {
            if (inventoryManager.isOpened == false)
            {
                if (hotBarInventory.activeSlot != null)
                {
                    if (hotBarInventory.activeSlot.item != null)
                    {
                        var weapon = hotBarInventory.activeSlot.item;
                        if (weapon.itemType == ItemType.Weapon)
                        {
                            nextTimeToFire = 1 / weapon.fireRate;
                            Shoot(weapon.bulletPrefab, weapon.bulletSpeed, weapon.damage, weapon.range);
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
