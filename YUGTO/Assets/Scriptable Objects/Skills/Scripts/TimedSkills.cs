using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Timed Skill", menuName = "Abilities/Timed Skill")]
public class TimedSkills : Abilities
{
    public float abilityDuration;
    public GameObject skillButtonPrefab;
}
