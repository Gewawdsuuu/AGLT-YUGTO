using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTestScript : MonoBehaviour
{
    public GameObject skillPrefab;

    public List<GameObject> playerGameObjects = new List<GameObject>();

    private void Start()
    {
        GameObject newBoostMoraleObject;
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerGameObjects.Add(fooObj);
        }

        for (int i = 0; i < playerGameObjects.Count; i++)
        {
            newBoostMoraleObject = Instantiate(skillPrefab, new Vector3((playerGameObjects[i].transform.position.x + 1), playerGameObjects[i].transform.position.y, playerGameObjects[i].transform.position.z), transform.rotation);
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {

        }
    }
}
