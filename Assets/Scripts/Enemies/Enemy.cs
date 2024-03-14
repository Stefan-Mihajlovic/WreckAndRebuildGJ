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
    private Transform player;
    private Rigidbody2D rb;
    public Vector3 currentGoal;
    private PlayerSensor playerSensor;

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
        playerSensor.StateUpdate();
        TakeAction();
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


    private void TakeAction()
    {
        switch (state)
        {
            case State.Idle:
                rb.velocity = new Vector3(0, 0, 0);
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
        rb.velocity = (currentGoal - transform.position).normalized * movementSpeed;
    }
    private void Attack()
    {
        Debug.Log("Attacking");
        rb.velocity = new Vector3(0,0,0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(currentGoal,0.3f);
    }
}
