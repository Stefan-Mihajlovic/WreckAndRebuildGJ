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

}
