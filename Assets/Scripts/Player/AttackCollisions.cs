using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisions : MonoBehaviour
{
    private List<Enemy> alreadyHit;
    Player player;
    private void Start()
    {
        alreadyHit = new List<Enemy>();
        player = transform.parent.parent.GetComponent<Player>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            alreadyHit.Clear();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!alreadyHit.Contains(collision.GetComponent<Enemy>()))
            {
                alreadyHit.Add(collision.GetComponent<Enemy>());
                collision.GetComponent<Enemy>().TakeDamage(player.weaponHolder.baseWeapon.damage + player.weaponHolder.headWeapon.damage);
            }
        }
        Debug.Log("tinuninu");
    }
}
