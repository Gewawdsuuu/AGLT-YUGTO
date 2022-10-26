using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fighter Class", menuName = "Heroes/Class/Fighter")]
public class FighterClass : Heroes
{

    public void Awake()
    {
        heroClass = HeroClass.Fighter;
    }
}
