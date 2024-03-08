using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] public WeaponImages weaponImages;
    public WeaponItem baseWeapon;
    public WeaponItem headWeapon;

    private void Start()
    {
        baseWeapon = Database.GetRandomBaseItem();
        headWeapon = Database.GetRandomHeadItem();
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
