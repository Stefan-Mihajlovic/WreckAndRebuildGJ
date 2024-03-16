using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Player player;
    public float attackDuration;
    private float currentAttackTime;
    private bool isAttacking = false;

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
        }
    }
}
