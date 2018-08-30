using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damage : MonoBehaviour
{
    [HideInInspector]
    public int damageAmount = 0;

    [HideInInspector]
    public DamageSourceType source = DamageSourceType.Other;

    abstract public void damageTaken();
}

public enum DamageSourceType
{
    Player = 1,
    Enemy = 2,
    Other = 3
}