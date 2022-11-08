using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaEnemy : MonoBehaviour
{
    public Enemies enemy;
    public EnemyAI enemyAI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyAI.target.GetComponent<PlayerController>().TakeDamage(enemyAI.enemyDamage);
            //GameObject.FindWithTag("Player").GetComponent<PlayerController>().TakeDamage(enemy.enemyDamage);
        }
    }
}
