using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponImages : MonoBehaviour
{
    [SerializeField] private List<Sprite> baseWeaponImages;
    [SerializeField] private List<Sprite> headWeaponImages;
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
        switch (weaponHolder.baseWeapon.itemName)
        {
            case "Wood plank": baseItem.sprite = baseWeaponImages[0]; break;
            case "PVC pipe": baseItem.sprite = baseWeaponImages[1]; break;
            case "Metal pipe": baseItem.sprite = baseWeaponImages[2]; break;
            case "Broomstick": baseItem.sprite = baseWeaponImages[3]; break;
            case "Power drill": baseItem.sprite = baseWeaponImages[4]; break;
            case "Chain": baseItem.sprite = baseWeaponImages[5]; break;
            case "Wrench": baseItem.sprite = baseWeaponImages[6]; break;
        }
        switch (weaponHolder.headWeapon.itemName)
        {
            case "Sawblade": headItem.sprite = headWeaponImages[0]; break;
            case "Drill head": headItem.sprite = headWeaponImages[1]; break;
            case "Hammer head": headItem.sprite = headWeaponImages[2]; break;
            case "Lighter": headItem.sprite = headWeaponImages[3]; break;
            case "Dynamite": headItem.sprite = headWeaponImages[4]; break;
            case "Rubber duck": headItem.sprite = headWeaponImages[5]; break;
            case "Car battery": headItem.sprite = headWeaponImages[6]; break;
        }
    }
}
