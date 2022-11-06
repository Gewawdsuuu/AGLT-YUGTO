using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkTrapPrefabScript : MonoBehaviour
{
    public TimedSkills timedSkills;
    public Animator skillAnimator;
    private BoxCollider2D collider;

    private float skillDuration;
    private float timeColliding;
    public float timeThreshold = 1f;
    private bool beginDamage;

    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
        skillAnimator = gameObject.GetComponent<Animator>();
        skillDuration = timedSkills.abilityDuration;
        beginDamage = false;
        timeColliding = 0f;
    }

    void Update()
    {
        Debug.Log(timeColliding);
    }

    public void setIdleAnimation()
    {
        skillAnimator.SetInteger("state", 1);
        beginDamage = true;
        StartCoroutine(WaitForDuration());
    }

    IEnumerator WaitForDuration()
    {
        yield return new WaitForSeconds(skillDuration);
        skillAnimator.SetInteger("state", 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(timedSkills.abilityDamage);
            collider.enabled = false;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        if (timeColliding < timeThreshold)
    //        {
    //            timeColliding += Time.deltaTime;
    //        }
    //        else
    //        {
    //            collision.gameObject.GetComponent<Enemy>().TakeDamage(timedSkills.abilityDamage);
    //            timeColliding = 0f;
    //        }
    //    }
    //}

    public void ColliderReset()
    {
        StartCoroutine(ResetCollider());
    }

    IEnumerator ResetCollider()
    {
        yield return new WaitForSeconds(0.5f);
        collider.enabled = true;
    }


    public void DestroyAfterAnimation()
    {
        Destroy(this.gameObject);
    }
}
