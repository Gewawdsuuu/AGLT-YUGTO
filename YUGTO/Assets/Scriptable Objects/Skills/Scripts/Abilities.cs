using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abilities : ScriptableObject
{
    public string abilityName;

    public float abilityLevel;
    public float abilityDamage;

    public float abilityCooldown;

    public float abilityManacost;

    public Sprite abilitySprite;

    public GameObject abilityPrefab;

}
