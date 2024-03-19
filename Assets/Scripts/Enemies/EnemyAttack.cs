using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Enemy enemy;
    [SerializeField] private float cooldown;
    private float currentCooldown;
    private bool isAttacking = false;
    public float attackDuration;
    private float currentAttackTime;

    private void Start()
    {
        currentCooldown = cooldown;
        enemy = GetComponent<Enemy>();
        enemy.enemyAttack.attackDuration = 5f / (enemy.weaponHolder.baseWeapon.speed + enemy.weaponHolder.headWeapon.speed);
    }
    private void Update()
    {
        if (isAttacking) 
        {
            currentAttackTime -= Time.deltaTime;
        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
        if (currentAttackTime <= 0)
        {
            isAttacking = false;
            currentCooldown += currentAttackTime;
        }
    }
    public void AttackOrCooldown()
    {
        Debug.Log("saftaj jaja");
        if (currentCooldown <= 0 && !isAttacking)
        {
            Debug.Log("samo jaja");
            currentCooldown = cooldown;
            currentAttackTime = attackDuration;
            Attack();
        }
    }

    virtual protected void Attack() 
    {
        if (!isAttacking)
        {
            isAttacking = true;
            currentAttackTime = attackDuration;
            enemy.animator.SetTrigger("Attack");
            Debug.Log("aaaa");
            SoundManager.PlaySound(SoundManager.Sound.NormalAttack);
        }
    }
}
