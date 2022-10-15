using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [Header("Pathfinding Attributes")]
    public Transform target;
    public float speed;
    public float minimumDistance;
    public Animator animator;

    PlayerController playerController;

    [Header("Enemy Attack Attributes")]
    [SerializeField] private GameObject attackArea;
    [SerializeField] private float timeToAttack;
    [SerializeField] private float enemyDamage = 5f;
    private float timer = 0f;
    public bool attacking = false;

    private void Update()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) > minimumDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                // Attack Code
                Attack();

                if (attacking)
                {
                    timer += Time.deltaTime;

                    if (timer >= timeToAttack)
                    {
                        timer = 0f;
                        attacking = false;
                        attackArea.SetActive(attacking);
                    }
                }
            }
        }
        else
        {
            GetComponent<AIDestinationSetter>().enabled = false;
        }
    }

    private void Attack()
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
