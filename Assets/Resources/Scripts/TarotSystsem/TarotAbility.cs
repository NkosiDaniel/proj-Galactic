using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TarotAbility : ScriptableObject
{
    [SerializeField] private string abilityName;
    public abstract void Execute();

}
