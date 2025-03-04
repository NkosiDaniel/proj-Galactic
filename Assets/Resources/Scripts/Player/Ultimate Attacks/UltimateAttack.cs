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
    [SerializeField] private int activationCost;
    [SerializeField] private int damage;
    protected virtual void Execute()
    {
        Debug.Log("Beam Attack has Executed!");
    }

    public String Name {get { return name;}}
    public String Description {get { return description;}}
    public float ActivationTime {get { return activationTime;}}
    public float CooldownTime {get { return cooldownTime;}}
    public int ActivationCost {get {return activationCost;}}
    public int Damage {get {return damage;}}

}
