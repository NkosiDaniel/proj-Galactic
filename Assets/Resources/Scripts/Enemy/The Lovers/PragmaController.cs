using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using COMMAND;

public class PragmaController : Enemy
{
    //TIMER INFO
    private float activationTimer;
    private float activationTime = 8f;
    private float restTimer;
    private Command shootCommand;

    

    private void Start()
    {
        CurrentHealth = HealthBar.Count;
        MaxHealth = HealthBar.Count;

        activationTimer = activationTime;

        phase = Phases.Base;

        restTimer = 10f;

        shootCommand = new ShootCommand(fireSpeed, fireRate, projectilePrefab, shootOrigins, nextFire);

        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = transform;
    }

    private void Update()
    {
        //When Pragma is IDLE
        switch (phase)
        {
            case Phases.Base: 
                restTimer -= Time.deltaTime;
                if (restTimer <= 0)
                {
                    int randomNum = UnityEngine.Random.Range(0, 4);
                    if (randomNum < 4)
                    {
                        activationTimer = activationTime;
                        phase = Phases.Elite;
                        Debug.Log("IN ETHERIC MODE");
                    }
                    restTimer = 10f;
                }
                break;
            //When Pragma is in Etheric Mode 
            case Phases.Elite: 
                EthericMode();
                activationTimer -= Time.deltaTime;
                
                break;
        }

    }

    public override void Attack() 
    {
        shootOrigins[0].transform.LookAt(player);
        shootCommand.Execute();
    }



    private void EthericMode()
    {
        //Will keep running until activation time is out
        if(activationTimer >= 0)
        {
            //FOR ALL ENEMY ABILITIES
            //FREEZE
            //BARRAGE ATTACKS
            Attack();

            //INVINCIBILITY
            //REGENERATION
        }
        else
            phase = Phases.Base;
    }
}
