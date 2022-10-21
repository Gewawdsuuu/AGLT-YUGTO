using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cleric Class", menuName = "Heroes/Class/Cleric")]
public class ClericClass : Heroes
{
    public void Awake()
    {
        heroClass = HeroClass.Cleric;
    }
}
