using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTestScript : MonoBehaviour
{
    public GameObject skillPrefab;

    public List<GameObject> enemyGameObjects = new List<GameObject>();

    private void Start()
    {
        GameObject newPurifyObject;
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemyGameObjects.Add(fooObj);
        }

        for (int i = 0; i < enemyGameObjects.Count; i++)
        {
            newPurifyObject = Instantiate(skillPrefab, new Vector3(enemyGameObjects[i].transform.position.x, enemyGameObjects[i].transform.position.y, enemyGameObjects[i].transform.position.z), transform.rotation);
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {

        }
    }
}
