using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroClass
{
    Fighter,
    Ranger,
    Cleric,
    Mage,
    Rare
}

public abstract class Heroes : ScriptableObject
{
    public string heroName;
    public HeroClass heroClass;

    public float maxHealth;
    public float maxMana;

    public float damage;
    public float moveSpeed;

    public string ability1Name;
    [TextArea(15, 20)] public string ability1Description;
    public float ability1Damage;
    public float ability1Manacost;

    public string ability2Name;
    [TextArea(15, 20)] public string ability2Description;
    public float ability2Damage;
    public float ability2Manacost;
}
