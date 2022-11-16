using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShowerPrefabScript : MonoBehaviour
{
    public ProjectileSkills projectileSkills;
    public Animator skillAnimator;
    public bool moveSkill = false;

    private float speed;
    private void Start()
    {
        skillAnimator = gameObject.GetComponent<Animator>();
        speed = projectileSkills.projectileSpeed;
    }

    private void FixedUpdate()
    {
        if (moveSkill)
        {
            MoveStar();
        }
    }

    public void SetMove()
    {
        skillAnimator.SetBool("isIdle", true);
        moveSkill = true;
    }

    public void MoveStar()
    {
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
    }

    public void OnHit()
    {
        skillAnimator.SetBool("isDestroy", true);
        moveSkill= false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bounds")
        {
            skillAnimator.SetBool("isIdle", false);
            StartCoroutine(WaitBeforeDestroy());
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(projectileSkills.abilityDamage);
            skillAnimator.SetBool("isIdle", false);
            StartCoroutine(WaitBeforeDestroy());
        }
    }

    IEnumerator WaitBeforeDestroy()
    {
        OnHit();
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
