using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float movementSpeed;
    [SerializeField] public WeaponHolder weaponHolder;
    private Transform player;
    private Rigidbody2D rb;
    public Vector3 currentGoal;
    private PlayerSensor playerSensor;
    public EnemyAttack enemyAttack;
    public Animator animator;
    public Animator spriteAnimator;
    private bool isFacingRight = true;

    public enum State 
    {
        Idle,
        Chasing,
        Attacking
    }
    public State state = State.Idle;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSensor = GetComponentInChildren<PlayerSensor>();
        rb = GetComponent<Rigidbody2D>();
        currentGoal = transform.position;
        enemyAttack = GetComponent<EnemyAttack>();
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void FixedUpdate()
    {
        playerSensor.StateUpdate();
        TakeAction();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);
    }

    private void Heal(int amount)
    {
        currentHealth += amount;

        healthBar.SetHealth(currentHealth);
    }


    private void TakeAction()
    {
        switch (state)
        {
            case State.Idle:
                rb.velocity = new Vector3(0, 0, 0);
                spriteAnimator.SetBool("Running", false);
                break;
            case State.Chasing:
                Chase();
                break;
            case State.Attacking:
                Attack();
                break;
        }
    }

    private void Chase()
    {
        Vector2 distance = (currentGoal - transform.position).normalized;
        rb.velocity = distance * movementSpeed;
        if (isFacingRight && rb.velocity.x < 0f || !isFacingRight && rb.velocity.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
        spriteAnimator.SetBool("Running", true);

    }
    private void Attack()
    {
        Debug.Log("jedi gobna");
        spriteAnimator.SetBool("Running", false);
        rb.velocity = new Vector3(0,0,0);
        enemyAttack.AttackOrCooldown();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(currentGoal,0.3f);
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}

