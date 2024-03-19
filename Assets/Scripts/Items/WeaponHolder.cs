using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] public WeaponImages weaponImages;
    public WeaponItem baseWeapon;
    public WeaponItem headWeapon;
    private Transform baseHolder;
    private Transform headHolder;


    private void Start()
    {
        baseWeapon = Database.GetRandomBaseItem();
        baseHolder = transform.GetChild(0);
        headHolder = baseHolder.GetChild(0);
        if (gameObject.layer == 3)
        {
            weaponImages.UpdateImages();
        }
        UpdateWeapon();
    }

    public void UpdateWeapon()
    {
        baseHolder.GetComponent<SpriteRenderer>().enabled = true;
        headHolder.GetComponent<SpriteRenderer>().enabled = true;
        if (headWeapon.itemID == "none")
        {
            headHolder.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            headHolder.GetComponent<SpriteRenderer>().sprite = headWeapon.sprite; 
            headHolder.position = baseHolder.position +
             new Vector3(
                 baseHolder.GetComponent<SpriteRenderer>().bounds.size.x / 2 * transform.parent.localScale.x,
             baseHolder.GetComponent<SpriteRenderer>().bounds.size.y / 2,
             baseHolder.position.z);
        }
        if (baseWeapon.itemID == "none")
        {
            baseHolder.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            baseHolder.GetComponent<SpriteRenderer>().sprite = baseWeapon.sprite;
        }
    }
}
