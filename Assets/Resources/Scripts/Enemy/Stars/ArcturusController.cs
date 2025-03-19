using System.Collections;
using System.Collections.Generic;
using COMMAND;
using UnityEngine;

public class ArcturusController : Enemy
{
    Command shootCommand;

    void Start()
    {
        CurrentHealth = HealthBar.Count;
        MaxHealth = HealthBar.Count;

        shootCommand = new ShootCommand(fireSpeed, fireRate, projectilePrefab, shootOrigins, nextFire);

        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = transform;

        phase = Phases.Base;
    }
    void Update()
    {
        Attack();
    }
    public override void Attack()
    {
        shootOrigins[0].gameObject.transform.LookAt(player);
        shootCommand.Execute();
    }

}
