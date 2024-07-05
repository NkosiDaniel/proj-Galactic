using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Phases 
{
    Introduction,
    FirstAttack,
    SecondAttack,
    FinalAttack,
    End
};

public class Enemy : SpaceshipBase
{
    Phases phase;
    private void Start() 
    {
        phase = Phases.FirstAttack;
    }

    
}
