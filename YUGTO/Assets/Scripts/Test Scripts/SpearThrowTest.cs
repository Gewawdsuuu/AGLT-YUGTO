using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowTest : MonoBehaviour
{
    public ProjectileSkills projectileSkills;
    public Animator skillAnimator;
    public bool moveSkill = false;

    private Rigidbody2D rb;
    private float speed;

    private void Start()
    {
        skillAnimator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        speed = projectileSkills.projectileSpeed;
    }

    private void FixedUpdate()
    {
        if (moveSkill)
        {
            MoveSpear();
        }
    }


    public void SetMove()
    {
        moveSkill = true;
    }

    public void MoveSpear()
    {
        transform.position += new Vector3(-100 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bounds")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(projectileSkills.abilityDamage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bounds")
        {
            Destroy(this.gameObject);
        }
    }
}
