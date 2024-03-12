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
    private Transform player;
    private Vector3 currentGoal;
    private bool reachedGoal = false;
    [SerializeField] private float reachedGoalDistance;
    [SerializeField] private float playerDetectionRadius;
    [SerializeField] private float attackRange;


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
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
    private void FixedUpdate()
    {
        StateUpdate();
    }

    private void TakeDamage(int amount)
    {
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);
    }

    private void Heal(int amount)
    {
        currentHealth += amount;

        healthBar.SetHealth(currentHealth);
    }

    private void StateUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            state = State.Attacking;
        }
        else
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, player.position - transform.position);
            if (Vector2.Distance(transform.position, player.position) <= playerDetectionRadius && ray.collider.CompareTag("Player"))
            {
                currentGoal = player.position;
                state = State.Chasing;
            }
            else
            {
                reachedGoal = Vector2.Distance(transform.position, currentGoal) <= reachedGoalDistance;
                if (reachedGoal)
                {
                    state = State.Idle;
                }
            }
        }
    }

    private void TakeAction()
    {
        switch (state)
        {
            case State.Idle:
                Debug.Log("Idle");
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
        Debug.Log("Chasing");
    }
    private void Attack()
    {
        Debug.Log("Attacking");
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position,Vector3.forward, playerDetectionRadius);
        Handles.DrawWireDisc(transform.position, Vector3.forward, attackRange);
        Handles.DrawWireDisc(transform.position, Vector3.forward, reachedGoalDistance);
    }
}
