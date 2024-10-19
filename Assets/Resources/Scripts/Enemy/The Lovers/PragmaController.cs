using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PragmaController : Enemy
{
    //TIMER INFO
    private float activationTimer;
    private float activationTime = 8f;
    private float restTimer;

    

    private void Start()
    {
        activationTimer = activationTime;
        restTimer = 10f;
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
                    if (randomNum == 1)
                    {
                        activationTimer = activationTime;
                        phase = Phases.Elite;
                    }
                }
                break;
            //When Pragma is in Etheric Mode 
            case Phases.Elite: 
                activationTimer -= Time.deltaTime;

                if (activationTimer <= 0)
                {
                    phase = Phases.Base;
                }
                break;
        }

    }


    private void EthericMode()
    {
        //Will keep running until activation time is out
        while (activationTimer >= 0)
        {
            //FOR ALL ENEMY ABILITIES
            //FREEZE
            //BARRAGE ATTACKS


            //INVINCIBILITY
            //REGENERATION
        }
    }
}
