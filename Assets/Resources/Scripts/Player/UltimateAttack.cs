using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamAttack : UltimateAttack
{
    [Serialilzefield] private GameObject projectiles;
    private override void Execute()
    {
        Debug.Log("BeamAttack Attck has Executed");
public class UltimateAttack : ScriptableObject
{
    protected virtual void Execute() 
    {
        Debug.Log("Beam Attack has Executed!");
    }
}
