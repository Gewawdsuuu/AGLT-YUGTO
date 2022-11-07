using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyHealPrefabScript : MonoBehaviour
{
    public BuffSkills buffSkills;
    public Animator skillAnimator;
    private float healAmount;

    public List<GameObject> playerGameObjects = new List<GameObject>();

    void Start()
    {
        skillAnimator = gameObject.GetComponent<Animator>();

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerGameObjects.Add(fooObj);
        }
    }

    //public void HealCharacters()
    //{
    //    for (int i = 0; i < playerGameObjects.Count; i++)
    //    {
    //        healAmount = playerGameObjects[i].GetComponent<PlayerController>().maxHealth * buffSkills.HealAmount;
    //        playerGameObjects[i].GetComponent<PlayerController>().HealHealth(healAmount);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            healAmount = collision.gameObject.GetComponent<PlayerController>().maxHealth * buffSkills.HealAmount;
            collision.gameObject.GetComponent<PlayerController>().HealHealth(healAmount);
        }
    }

    public void DestroyObjectEvent()
    {
        Destroy(this.gameObject);
    }
}
