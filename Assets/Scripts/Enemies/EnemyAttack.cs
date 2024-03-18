using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Enemy enemy;
    [SerializeField] private float cooldown;
    private float currentCooldown;
    private bool isAttacking = false;
    [SerializeField] private float attackDuration;
    private float currentAttackTime;

    private void Start()
    {
        currentCooldown = cooldown;
        enemy = GetComponent<Enemy>();
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
        if (currentCooldown <= 0 && !isAttacking)
        {
            currentCooldown = cooldown;
            isAttacking = true;
            currentAttackTime = attackDuration;
            Attack();
        }
    }

    virtual protected void Attack() 
    {

    }
}
