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
    [SerializeField] private float timeToAttack = 0.25f;
    [SerializeField] private float timer = 0f;
    public float enemyDamage;
    public bool attacking = false;

    float lastShot;

    private void Start()
    {
        // Set Enemy parameters based on enemy type
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

        if (attacking)
        {
            timer += Time.deltaTime;

            if  (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    public void Attack()
    {
        if (attacking == false)
        {
            attacking = true;
            attackArea.SetActive(attacking);
            animator.SetTrigger("Attack");
        }
    }
}
