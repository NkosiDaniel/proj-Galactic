using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttacker: MonoBehaviour
{
    [SerializeField]Transform player;
    [SerializeField] Transform enemy;
    [SerializeField] List<GameObject> shootOrigins;
    [SerializeField] GameObject laser;
    [SerializeField]float fireRate;
    private Boolean isShooting = false;
    private Vector3 distance;
    private float distanceFrom;
    private float nextFire;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        Attack();

//Getting the maginitude of the distance between the player and the enemy 
        distance = (enemy.position - player.position);
        distance.y = 0;
        distanceFrom = distance.magnitude;
        distance /= distanceFrom;

        if(distanceFrom < 200)
            isShooting = true;
        else
            isShooting = false;
    }

    public void Attack() 
    {
        //Once the enemy is in range, it will face the player
        if(isShooting) 
        {
            enemy.LookAt(player);

            if(Time.time > nextFire) 
            {
                foreach(GameObject s in shootOrigins) 
                {
                    nextFire = Time.time + fireRate;
                    GameObject bullet = Instantiate(laser, s.transform.position, s.transform.rotation);
                    bullet.GetComponent<Rigidbody>().AddForce(s.transform.forward * 5000);
                    FindObjectOfType<AudioManager>().PlaySound("MetatronShoot");
                    Destroy(bullet, 2);
                }
            }
        }
    }
   
}


