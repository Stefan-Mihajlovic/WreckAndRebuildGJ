using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = this.GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Weapon")
        {
            WeaponItem newItem = collision.transform.GetComponent<LayingWeaponItem>().item;
            player.SetNewPlayerItem(newItem);
            Destroy(collision.gameObject);
        }
    }
}
