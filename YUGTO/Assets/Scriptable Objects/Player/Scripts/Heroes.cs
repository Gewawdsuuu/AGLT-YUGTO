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

    [Header("Base Stats")]
    public float currentHealth;
    public float maxHealth;
    public float healthRegen;

    public float currentMana;
    public float maxMana;
    public float manaRegen;

    public float armor;

    public float damage;
    public float moveSpeed;

    public float currentLevel;
    public float currentExperience;
    public float maxExperience;

    [Header("Stats")]
    public float strength;
    public float agility;
    public float intelligence;
    public float skillPoints;

    [Header("Abilities")]
    public string ability1Name;
    [TextArea(5, 10)] public string ability1Description;
    public float ability1Damage;
    public float ability1Manacost;

    public string ability2Name;
    [TextArea(5, 10)] public string ability2Description;
    public float ability2Damage;
    public float ability2Manacost;
}
