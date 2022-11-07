using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTestScript : MonoBehaviour
{
    public GameObject skillPrefab;
    public Transform player;

    public List<GameObject> playerGameObjects = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerGameObjects.Add(fooObj);
        }
    }

    private void Update()
    {
        GameObject newPartyHealObject;

        if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < playerGameObjects.Count; i++)
            {
                newPartyHealObject = Instantiate(skillPrefab, new Vector3(playerGameObjects[i].transform.position.x, playerGameObjects[i].transform.position.y, playerGameObjects[i].transform.position.z), transform.rotation);
            }
        }
    }
}
