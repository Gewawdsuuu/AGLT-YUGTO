using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkillTestScript : MonoBehaviour
{
    public TimedSkills skill;
    public GameObject prefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(prefab);
        }
    }
}
