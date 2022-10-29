using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotPrefabScript : MonoBehaviour
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
            MoveBullet();
        }
    }

    public void SetMove()
    {
        skillAnimator.SetBool("isIdle", true);
        moveSkill = true;
    }

    public void MoveBullet()
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
