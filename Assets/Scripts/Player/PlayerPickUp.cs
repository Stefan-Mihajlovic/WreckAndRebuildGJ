using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    private Player player;
    private Collider2D other = null;

    private void Start()
    {
        player = this.GetComponentInParent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && other != null)
        {
            WeaponItem newItem = other.transform.GetComponent<LayingWeaponItem>().item;
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            collision.transform.Find("UseButtonGfx").gameObject.SetActive(false);
            other = null;
        }
    }
}
