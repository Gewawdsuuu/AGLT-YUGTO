using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters
{
    public string heroName;

    public float maxHealth;
    public float healthRegen;

    public float maxMana;
    public float manaRegen;

    public float armor;

    public float damage;

    public float currentLevel;
    public float currentExperience;
    public float maxExperience;

    public float strength;
    public float agility;
    public float intelligence;
    public float skillPoints;

    public string ability1Name;
    public float ability1Damage;
    public float ability1Manacost;

    public string ability2Name;
    public float ability2Damage;
    public float ability2Manacost;

    public Characters(string heroName, float maxHealth, float healthRegen, float maxMana, float manaRegen, float armor, float damage, float currentLevel, float currentExperience,
        float maxExperience, float strength, float agility, float intelligence, float skillPoints, string ability1Name, float ability1Damage, float ability1Manacost, string ability2Name,
        float ability2Damage, float ability2Manacost)
    {
        this.heroName = heroName;
        this.maxHealth = maxHealth;
        this.healthRegen = healthRegen;
        this.maxMana = maxMana;
        this.manaRegen = manaRegen;
        this.armor = armor;
        this.damage = damage;
        this.currentLevel = currentLevel;
        this.currentExperience = currentExperience;
        this.maxExperience = maxExperience;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.skillPoints = skillPoints;
        this.ability1Name = ability1Name;
        this.ability1Damage = ability1Damage;
        this.ability1Manacost = ability1Manacost;
        this.ability2Name = ability2Name;
        this.ability2Damage = ability2Damage;
        this.ability2Manacost = ability2Manacost;
    }
}

public class PlayFabCharacterData : MonoBehaviour
{
    public Heroes hero;

    public Characters ReturnClass()
    {
        return new Characters(hero.name, hero.maxHealth, hero.healthRegen, hero.maxMana, hero.manaRegen, hero.armor, hero.damage, hero.currentLevel,  hero.currentExperience,
            hero.maxExperience, hero.strength, hero.agility, hero.intelligence, hero.skillPoints, hero.ability1Name, hero.ability1Damage, hero.ability1Manacost, hero.ability2Name,
            hero.ability2Damage, hero.ability2Manacost);
    }
}
