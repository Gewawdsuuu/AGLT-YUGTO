using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderboltPrefabScript : MonoBehaviour
{
    public ProjectileSkills projectileSkills;
    public Animator skillAnimator;
    public bool moveSkill = false;

    private void Start()
    {
        skillAnimator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bounds")
        {
            StartCoroutine(WaitBeforeDestroy());
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(projectileSkills.abilityDamage);
            StartCoroutine(WaitBeforeDestroy());
        }
    }

    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
