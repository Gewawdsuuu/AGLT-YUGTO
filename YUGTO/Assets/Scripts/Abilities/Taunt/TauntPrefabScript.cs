using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TauntPrefabScript : MonoBehaviour
{
    public TimedSkills timedSkills;
    public Animator skillAnimator;
    public GameObject[] enemiesGameObject;

    private float skillDuration;
    public Transform newTarget;
    public Transform oldTarget;

    public bool isNewTarget = false;

    void Start()
    {
        skillAnimator = gameObject.GetComponent<Animator>();
        skillDuration = timedSkills.abilityDuration;
        oldTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        newTarget = GameObject.Find("GabrielaSilang").GetComponent<Transform>();
        enemiesGameObject = GameObject.FindGameObjectsWithTag("Enemy");
        isNewTarget = false;
    }

    private void Update()
    {
        if (isNewTarget)
        {
            UseTaunt();
            StartCoroutine(SetToOldTarget());
        }
    }

    public void SetNewTarget()
    {
        isNewTarget = true;
    }

    public void UseTaunt()
    {
        for (int i = 0; i < enemiesGameObject.Length; i++)
        {
            enemiesGameObject[i].GetComponent<EnemyAI>().target = newTarget;
        }
    }

    IEnumerator SetToOldTarget()
    {
        yield return new WaitForSeconds(skillDuration);
        for (int i = 0; i < enemiesGameObject.Length; i++)
        {
            enemiesGameObject[i].GetComponent<EnemyAI>().target = oldTarget;
        }
        isNewTarget = false;
        Destroy(this.gameObject);
    }

}
