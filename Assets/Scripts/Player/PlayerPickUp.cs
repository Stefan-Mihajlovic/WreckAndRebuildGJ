
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    private Player player;
    private Collider2D other = null;
    [SerializeField] private GameObject itemDrop;

    private void Start()
    {
        player = this.GetComponentInParent<Player>();
    }

    private void ItemDrop(WeaponItem newItem)
    {
        GameObject oldItem = Instantiate(itemDrop, transform.position, new Quaternion());
        if (newItem.isBase)
        {
            oldItem.GetComponent<LayingWeaponItem>().item = player.weaponHolder.baseWeapon;
            //if (newItem.isStandalone)
            //{
            //    GameObject oldItemHead = Instantiate(itemDrop, transform.position + new Vector3(0.5f,0,0), new Quaternion());
            //    oldItemHead.GetComponent<LayingWeaponItem>().item = player.weaponHolder.headWeapon;
            //    player.weaponHolder.headWeapon = Database.GetItemByID("none");
            //    if (oldItemHead.GetComponent<LayingWeaponItem>().item.itemID == "none")
            //    {
            //        Destroy(oldItemHead);
            //    }
            //}
        }
        else
        {
            oldItem.GetComponent<LayingWeaponItem>().item = player.weaponHolder.headWeapon;
        }
        if (oldItem.GetComponent<LayingWeaponItem>().item.itemID == "none")
        {
            Destroy(oldItem);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && other != null)
        {
            WeaponItem newItem = other.transform.GetComponent<LayingWeaponItem>().item;
            if (!newItem.isBase && player.weaponHolder.baseWeapon.isStandalone)
            {
                Debug.Log("NEMEZE EJ");
            }
            else
            {
                if (newItem.isStandalone && newItem.isBase)
                {
                    WeaponItem none = Database.GetItemByID("none");
                    ItemDrop(none);
                    player.SetNewPlayerItem(none);
                }
                ItemDrop(newItem);
                player.SetNewPlayerItem(newItem);
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            collision.transform.Find("UseButtonGfx").gameObject.SetActive(true);
            other = collision;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            other = collision;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            collision.transform.Find("UseButtonGfx").gameObject.SetActive(false);
            other = null;
        }
    }
}
