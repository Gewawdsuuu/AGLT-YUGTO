using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rare Class", menuName = "Heroes/Class/Rare")]
public class RareClass : Heroes
{
    public void Awake()
    {
        heroClass = HeroClass.Rare;
    }
}
