using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Enemies enemyType;

    [Header("Pathfinding Attributes")]
    public Transform target;
    public float speed;
    public float minimumDistance;
    public Animator animator;

    PlayerController playerController;

    [Header("Enemy Attack Attributes")]
    [SerializeField] private GameObject attackArea;
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private float enemyDamage;
    public bool attacking = false;

    private void Start()
    {
        // Set Enemy parameters based on enemy type
        enemyDamage = enemyType.enemyDamage;
        speed = enemyType.enemyMovespeed;

        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        target = temp.GetComponent<Transform>();
    }

    private void Update()
    {
        if  (target != null)
        {
            // Continue to move towards the target if not close enough
            if (Vector2.Distance(transform.position, target.position) > minimumDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                // Attack Code
                Attack();
            }
        }
        else
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");
            if (temp  != null)
            {
                target = temp.GetComponent<Transform>();
            }
        }
    }

    public void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        animator.SetTrigger("Attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (attacking)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameObject.FindWithTag("Player").GetComponent<PlayerController>().TakeDamage(enemyDamage);
            }
        }
    }
}
