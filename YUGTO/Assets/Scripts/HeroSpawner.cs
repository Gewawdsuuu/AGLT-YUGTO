using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{

    public GameObject[] spawnPoints;

    private void Awake()
    {
        GameObject prefabs;
        for (int i = 0; i < HeroSelection.selectedHeroName.Count; i++)
        {
            prefabs = (GameObject)Instantiate(Resources.Load(HeroSelection.selectedHeroName[i]), spawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}
