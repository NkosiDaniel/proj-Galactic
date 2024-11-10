using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeamAttack : UltimateAttack
{
    [SerializeField] private GameObject projectile;
    protected override void Execute() 
    {
        Debug.Log("Beam Attack has Executed!");
    }
}
