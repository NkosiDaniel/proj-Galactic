using System.Collections;
using System.Collections.Generic;
using COMMAND;
using Unity.VisualScripting;
using UnityEngine;

public class ManiaController : Enemy
{

    private int attackCounter = 0;
    private Command strongAttack;
    private Command weakAttack;
    [Header("Alternate Attack Info")]
    [SerializeField] private GameObject secProjectile;
    [SerializeField] private List<GameObject> secShootOrigins;
    private void Start()
    {
        //HEALTH STATS
        CurrentHealth = HealthBar.Count;
        MaxHealth = HealthBar.Count;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        strongAttack = new ShootCommand(fireSpeed, fireRate * 1.2f, projectilePrefab, shootOrigins);
        weakAttack = new ShootCommand(fireSpeed, fireRate, secProjectile, secShootOrigins);
    }

    private void Update()
    {
        Attack();
    }

    public override void Attack()
    {
        attackCounter++;
        secShootOrigins[0].transform.LookAt(player);
        weakAttack.Execute();

        if (attackCounter == 3)
        {
            shootOrigins[0].transform.LookAt(player);
            strongAttack.Execute();
            attackCounter = 0;
        }
    }

    
}
