using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private WeaponImages weaponImages;
    public WeaponItem baseWeapon;
    public WeaponItem headWeapon;

    private void Start()
    {
        baseWeapon = new WeaponItem("Broomstick", 0, 0, false, true);
        headWeapon = new WeaponItem("Car battery", 0, 0, false, false);
        weaponImages.UpdateImages();
    }

    public void Attack()
    {
        //animation, collider enabling(switch)
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //damaging of the enemies
        //baseWeapon.damage + headWeapon.damage
        //effect(headWeapon.itemName)
    }
}
