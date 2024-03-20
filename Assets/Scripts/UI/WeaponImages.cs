using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponImages : MonoBehaviour
{
    [SerializeField] private WeaponHolder weaponHolder;
    private Image baseItem;
    private Image headItem;

    private void Awake()
    {
        baseItem = transform.Find("BaseWeapon").GetComponent<Image>();
        headItem = transform.Find("HeadWeapon").GetComponent<Image>();
    }

    public void UpdateImages()
    {
        baseItem.enabled = true;
        headItem.enabled = true;
        if (weaponHolder.headWeapon.itemID == "none")
        {
            headItem.enabled = false;
        }
        else
        {
            headItem.sprite = weaponHolder.headWeapon.sprite;
        }
        if (weaponHolder.baseWeapon.itemID == "none")
        {
            baseItem.enabled = false;
        }
        else
        {
            baseItem.sprite = weaponHolder.baseWeapon.sprite;
        }
    }
}
