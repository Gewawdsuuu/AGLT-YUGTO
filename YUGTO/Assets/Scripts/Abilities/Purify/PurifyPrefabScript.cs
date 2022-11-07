using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurifyPrefabScript : MonoBehaviour
{
    public ProjectileSkills projectileSkills;
    public Animator skillAnimator;

    // Start is called before the first frame update
    void Start()
    {
        skillAnimator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(projectileSkills.abilityDamage);
        }
    }

    public void DestroyAfterEvent()
    {
        Destroy(this.gameObject, 1f);
    }
}
