using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    private bool reachedGoal = false;
    [SerializeField] private float reachedGoalDistance;
    [SerializeField] private float playerDetectionRadius;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask scanMask;
    private Enemy enemy;
    private Transform player;
    void Start()
    {
        enemy = transform.parent.GetComponent<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {

    }
    public void StateUpdate()
    {
        if (player == null)
            return;
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            enemy.state = Enemy.State.Attacking;
        }
        else
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, player.position - transform.position,Mathf.Infinity, scanMask);
            Debug.DrawRay(transform.position, player.transform.position - transform.position);
            if (Vector2.Distance(transform.position, player.position) <= playerDetectionRadius && ray.collider.CompareTag("Player"))
            {
                enemy.currentGoal = player.position;
                enemy.state = Enemy.State.Chasing;
            }
            else
            {
                reachedGoal = Vector2.Distance(transform.position, enemy.currentGoal) <= reachedGoalDistance;
                if (reachedGoal)
                {
                    enemy.state = Enemy.State.Idle;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, playerDetectionRadius);
        Handles.DrawWireDisc(transform.position, Vector3.forward, attackRange);
        Handles.DrawWireDisc(transform.position, Vector3.forward, reachedGoalDistance);
    }
}
