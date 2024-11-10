using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateAttack : ScriptableObject
{
    [SerializeField] private String name;
    [SerializeField] private String description;
    [SerializeField] private float activationTime;
    [SerializeField] private float cooldown;
    [SerializeField] private float damage;

    protected virtual void Execute() 
    {
        Debug.Log("Ultimate Attack has Executed!");
    }
}
