using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ranger Class", menuName = "Heroes/Class/Ranger")]
public class RangerClass : Heroes
{
    public void Awake()
    {
        heroClass = HeroClass.Ranger;
    }
}
