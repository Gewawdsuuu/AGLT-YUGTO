using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowPrefab : MonoBehaviour
{
    public ProjectileSkills projectileSkills;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3((projectileSkills.projectileSpeed * Time.deltaTime) * -1, 0, 0);
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
}
