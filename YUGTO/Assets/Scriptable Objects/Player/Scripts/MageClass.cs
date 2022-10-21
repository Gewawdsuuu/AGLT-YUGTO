using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mage Class", menuName = "Heroes/Class/Mage")]
public class MageClass : Heroes
{
    public void Awake()
    {
        heroClass = HeroClass.Mage;
    }
}
