using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollisions : MonoBehaviour
{
    Enemy enemy;
    private void Start()
    {
        enemy = transform.parent.parent.GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(enemy.weaponHolder.baseWeapon.damage + enemy.weaponHolder.headWeapon.damage);
        }
    }
}
