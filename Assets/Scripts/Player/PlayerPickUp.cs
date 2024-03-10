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

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && other != null)
        {
            WeaponItem newItem = other.transform.GetComponent<LayingWeaponItem>().item;
            GameObject oldItem = Instantiate(itemDrop, transform.position, new Quaternion());
            if (newItem.isBase) 
            {
                oldItem.GetComponent<LayingWeaponItem>().item = player.weaponHolder.baseWeapon;
            }
            else
            {
                oldItem.GetComponent<LayingWeaponItem>().item = player.weaponHolder.headWeapon;
            }
            player.SetNewPlayerItem(newItem);
            Destroy(other.gameObject);
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
