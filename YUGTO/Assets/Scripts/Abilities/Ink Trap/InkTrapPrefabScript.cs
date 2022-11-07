using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkTrapPrefabScript : MonoBehaviour
{
    public TimedSkills timedSkills;
    private Animator skillAnimator;
    private float skillDuration;
    private GameObject enemyCol;
    private float normalEnemySpeed;

    void Start()
    {
        skillAnimator = gameObject.GetComponent<Animator>();
        skillDuration = timedSkills.abilityDuration;
    }

    public void setIdleAnimation()
    {
        skillAnimator.SetInteger("state", 1);
        enemyCol.GetComponent<EnemyAI>().speed = 0f;
        StartCoroutine(WaitForDuration());
    }

    IEnumerator WaitForDuration()
    {
        yield return new WaitForSeconds(skillDuration);
        enemyCol.GetComponent<EnemyAI>().speed = normalEnemySpeed;
        skillAnimator.SetInteger("state", 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyCol = collision.gameObject;
            normalEnemySpeed = collision.gameObject.GetComponent<EnemyAI>().speed;
        }
    }

    public void TakeDamage()
    {
        enemyCol.GetComponent<Enemy>().TakeDamage(timedSkills.abilityDamage);
    }

    public void DestroyAfterAnimation()
    {
        Destroy(this.gameObject);
    }
}
