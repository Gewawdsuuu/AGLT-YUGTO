using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndyingRagePrefabScript : MonoBehaviour
{
    public BuffSkills buffSkills;
    public Animator skillAnimator;

    public List<GameObject> enemyGameObjects = new List<GameObject>();
    public List<float> oldEnemyDamage = new List<float>();
    public float newEnemyDamage = 0f;

    // Start is called before the first frame update

    private void Awake()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemyGameObjects.Add(fooObj);
            oldEnemyDamage.Add(fooObj.GetComponent<EnemyAI>().enemyDamage);
        }

    }

    void Start()
    {
        skillAnimator = gameObject.GetComponent<Animator>();
        newEnemyDamage = 0f;

        StartCoroutine(WaitBeforeDestroy());
    }

    private void Update()
    {
        for (int i = 0; i < enemyGameObjects.Count; i++)
        {
            enemyGameObjects[i].GetComponent<EnemyAI>().enemyDamage = newEnemyDamage;
        }

        for (int i = 0; i < enemyGameObjects.Count; i++)
        {
            if (enemyGameObjects[i] == null)
            {
                enemyGameObjects.RemoveAt(i);
            }
        }
    }

    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(buffSkills.buffDuration);

        for (int i = 0; i < enemyGameObjects.Count; i++)
        {
            enemyGameObjects[i].GetComponent<EnemyAI>().enemyDamage = oldEnemyDamage[i];
        }

        Destroy(this.gameObject);
    }

}
 