using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    [SerializeField] public WeaponHolder weaponHolder;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            weaponHolder.baseWeapon = Database.GetRandomBaseItem();
            weaponHolder.headWeapon = Database.GetRandomHeadItem();
            weaponHolder.weaponImages.UpdateImages();
            weaponHolder.UpdateWeapon();
        }
    }

    private void TakeDamage(int amount)
    {
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);
    }

    private void Heal(int amount)
    {
        currentHealth += amount;

        healthBar.SetHealth(currentHealth);
    }

    public void SetNewPlayerItem(WeaponItem newItem)
    {
        if(newItem.isBase)
        {
            weaponHolder.baseWeapon = newItem;
        }
        else
        {
            weaponHolder.headWeapon = newItem;
        }
        weaponHolder.weaponImages.UpdateImages();
        weaponHolder.UpdateWeapon();
    }
}
