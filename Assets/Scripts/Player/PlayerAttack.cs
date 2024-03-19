using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerAttack : MonoBehaviour
{
    private Player player;
    public float attackDuration;
    private float currentAttackTime;
    private bool isAttacking = false;

    private void Start()
    {
        player = GetComponent<Player>();
        player.playerAttack.attackDuration = 5f / (player.weaponHolder.baseWeapon.speed + player.weaponHolder.headWeapon.speed);
    }

    private void Update()
    {
        if (isAttacking)
        {
            currentAttackTime -= Time.deltaTime;
        }
        if (currentAttackTime<=0)
        {
            currentAttackTime = 0;
            isAttacking = false;
        }
    }

    public void Attack() 
    {
        if (!isAttacking)
        {
            isAttacking = true;
            currentAttackTime = attackDuration;
            player.animator.SetTrigger("Attack");
            SoundManager.PlaySound(SoundManager.Sound.NormalAttack);
        }
    }
}
