using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Buff Skill", menuName = "Abilities/Buff Skill")]
public class BuffSkills : Abilities
{
    public float HealAmount;
    public GameObject skillButtonPrefab;
    public float attackAddition;
    public float buffDuration;
}
