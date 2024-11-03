using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using COMMAND;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using DG.Tweening;

public class PragmaController : Enemy
{
    [SerializeField] GameObject pragmaEye;
    //TIMER INFO
    private float activationTimer;
    private float activationTime = 8f;
    private float restTimer;
    private Command shootCommand;
    private BoxCollider boxCollider;
    private Color color;
    private bool colorChange = false;



    private void Start()
    {
        //HEALTH STATS
        CurrentHealth = HealthBar.Count;
        MaxHealth = HealthBar.Count;
        //ETHERIC MODE TIME
        activationTimer = activationTime;

        phase = Phases.Base;
        //BASE MODE TIME
        restTimer = 10f;

        shootCommand = new ShootCommand(fireSpeed, fireRate, projectilePrefab, shootOrigins, nextFire);

        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = transform;

        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        //When Pragma is IDLE
        switch (phase)
        {
            case Phases.Base:
                pragmaEye.SetActive(false);
                colorChange = false;
                restTimer -= Time.deltaTime;

                if (restTimer <= 0)
                {
                    int randomNum = UnityEngine.Random.Range(0, 4);
                    if (randomNum < 4)
                    {
                        activationTimer = activationTime;
                        phase = Phases.Elite;
                        //INVINCIBILITY
                        Invincible();

                        pragmaEye.SetActive(true);
                        ShakeEye();

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

    private void ShakeEye()
    {
        if (phase == Phases.Elite)
        {
            pragmaEye.transform.DOPunchScale(new Vector3(8f, 8f, 8f), 0.5f, 5, 0.5f);
        }
        else if (phase == Phases.Base)
        {
            pragmaEye.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f, 5, 0.5f);
        }
    }

    public override void Attack()
    {
        shootOrigins[0].transform.LookAt(player);
        shootCommand.Execute();
    }

    private void Invincible()
    {
        boxCollider.enabled = !boxCollider.enabled;

        color = boxCollider.enabled ? Color.magenta : Color.blue;

        if (colorChange == false)
        {
            foreach (GameObject s in HealthBar)
            {
                s.GetComponent<UnityEngine.UI.Image>().color = color;
            }
            colorChange = true;
        }
    }

    private void EthericMode()
    {
        //Will keep running until activation time is out
        if (activationTimer >= 0)
        {
            //FOR ALL ENEMY ABILITIES
            //FREEZE
            //BARRAGE ATTACKS
            Attack();

            //REGENERATION
        }
        else
        {
            Invincible(); 
            phase = Phases.Base;
            ShakeEye(); 
        }
    }
}
