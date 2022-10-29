using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowPrefabScript : MonoBehaviour
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
            MoveSpear();
        }
    }


    public void SetMove()
    {
        skillAnimator.SetInteger("isFalling", 1);
        moveSkill = true;
    }

    public void MoveSpear()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
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
