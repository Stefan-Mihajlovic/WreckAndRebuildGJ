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
        headWeapon = Database.GetRandomHeadItem();
        baseHolder = transform.GetChild(0);
        headHolder = baseHolder.GetChild(0);
        weaponImages.UpdateImages();
        UpdateWeapon();
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
        //baseHolder.GetComponent<SpriteRenderer>().sprite = baseWeapon.sprite;
        //headHolder.GetComponent<SpriteRenderer>().sprite = headWeapon.sprite;
        //headHolder.position = baseHolder.position +
        //    new Vector3(
        //        baseHolder.GetComponent<SpriteRenderer>().bounds.size.x / 2 * transform.parent.localScale.x,
        //    baseHolder.GetComponent<SpriteRenderer>().bounds.size.y / 2,
        //    baseHolder.position.z);
    }
}
