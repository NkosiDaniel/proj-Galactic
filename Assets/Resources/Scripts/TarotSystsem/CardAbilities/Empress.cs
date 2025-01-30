using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empress : TarotAbility
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerShield playerShield;

    override
    public void Execute()
    {
        playerHealth.SetMaxHealth();
        playerShield.SetMaxShield();
    }
}
