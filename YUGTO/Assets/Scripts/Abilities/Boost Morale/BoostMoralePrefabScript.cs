using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMoralePrefabScript : MonoBehaviour
{
    public BuffSkills buffSkills;
    private GameObject rizalObject;
    private float oldHeroDamage;
    private float rizalCurrentHealth;
    private GameObject collisionObject;

    // Start is called before the first frame update
    void Awake()
    {
        rizalObject = GameObject.Find("JoseRizal");
        rizalCurrentHealth = rizalObject.GetComponent<PlayerController>().maxHealth;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collisionObject = collision.gameObject;
            oldHeroDamage = collision.GetComponent<PlayerAttack>().playerDamage;
            collision.gameObject.GetComponent<PlayerAttack>().AddDamage(buffSkills.attackAddition);
            StartCoroutine(SetOldDamageWaiter());
        }
    }

    IEnumerator SetOldDamageWaiter()
    {
        yield return new WaitForSeconds(buffSkills.buffDuration);
        collisionObject.GetComponent<PlayerAttack>().SetDamage(oldHeroDamage);
        Destroy(this.gameObject, 1f);
    }

    public void DamageRizal()
    {
        rizalObject.GetComponent<PlayerController>().TakeDamage(rizalCurrentHealth * buffSkills.abilityDamage);
    }
}
