using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//First tarot ability coded, will be able to test later
public class HighPriestress : TarotAbility
{
    [SerializeField] private PlayerHealth playerHealth;
    override
    public void Execute() 
    {
        playerHealth.IncreaseMaximum();
    }
}
