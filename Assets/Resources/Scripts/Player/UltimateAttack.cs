using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateAttack : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private float activationTime;
    [SerializeField] private float cooldown;
    [SerializeField] private float damage;
    
    protected virtual static void Execute()
}   {
        Debug.Log("Ultimate Attack has Executed!");
}
