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
        baseItem.sprite = weaponHolder.baseWeapon.sprite;
        headItem.sprite = weaponHolder.headWeapon.sprite;
    }
}
