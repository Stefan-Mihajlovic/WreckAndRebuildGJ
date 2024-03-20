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
    private bool isEnemyDeathOn = false;
    private float newRotation = 0;
    public int RandomX, RandomY;

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
        animator.runtimeAnimatorController = weaponHolder.baseWeapon.animator;
        Debug.Log(weaponHolder.baseWeapon);
        RandomX = UnityEngine.Random.Range(10, 20);
        RandomY = UnityEngine.Random.Range(10, 20);
    }
    private void Update()
    {
        newRotation += Time.deltaTime * 50;
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
        if (isEnemyDeathOn)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, newRotation));
            transform.position += new Vector3(RandomX * Time.deltaTime, RandomY * Time.deltaTime, 0);
            transform.localScale += new Vector3(RandomX/5 * Time.deltaTime, RandomY/5 * Time.deltaTime, 0);
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
        spriteAnimator.SetBool("Running", false);
        rb.velocity = new Vector3(0,0,0);
        enemyAttack.attackIndicatore();
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(currentGoal,0.3f);
    }
    private IEnumerator Die()
    {
        Debug.Log("da");
        isEnemyDeathOn = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}

