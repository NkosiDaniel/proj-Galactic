using System;
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
    public GameObject laserPrefab;
    private Transform player;
    private Transform enemy;
    private float nextFire;
    private float fireRate = 1f;
    [SerializeField] List<GameObject> shootOrigins;
    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = transform;
        phase = Phases.FirstAttack;
    }

    public void Attack() 
    {
            enemy.LookAt(player);

            if(Time.time > nextFire) 
            {
                foreach(GameObject s in shootOrigins) 
                {
                    nextFire = Time.time + fireRate;
                    GameObject bullet = Instantiate(laserPrefab, s.transform.position, s.transform.rotation);
                    bullet.GetComponent<Rigidbody>().AddForce(s.transform.forward * 5000);
                    FindObjectOfType<AudioManager>().PlaySound("MetatronShoot");
                    Destroy(bullet, 2);
                }
            }
        }
    }

