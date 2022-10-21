using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemies : ScriptableObject
{
    public string EnemyName;

    public float enemyMaxhealth;
    public float enemyDamage;
    public float enemyMovespeed;
}
