using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Animator animator;

    [SerializeField] public WeaponHolder weaponHolder;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if(currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    public void SetNewPlayerItem(WeaponItem newItem)
    {
        if(newItem.isBase)
        {
            weaponHolder.baseWeapon = newItem;
            animator.runtimeAnimatorController = newItem.animator;
        }
        else
        {
            weaponHolder.headWeapon = newItem;
        }
        weaponHolder.weaponImages.UpdateImages();
        weaponHolder.UpdateWeapon();
    }
}
