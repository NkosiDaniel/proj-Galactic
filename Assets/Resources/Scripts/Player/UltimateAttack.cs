using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateAttack : ScriptableObject
{
    [SerializeField] private String name;
    [SerializeField] private String description;
    [SerializeField] private float activationTime;
    [SerializeField] private float cooldownTime;
    [SerializeField] private int damage;
    protected virtual void Execute() 
    {
        Debug.Log("Beam Attack has Executed!");
    }
}
