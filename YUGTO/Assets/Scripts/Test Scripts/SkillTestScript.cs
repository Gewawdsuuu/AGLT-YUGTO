using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTestScript : MonoBehaviour
{
    public GameObject skillPrefab;
    public Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(skillPrefab, new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z), transform.rotation);
    }
}
