using System;
using System.Collections;
using System.Collections.Generic;
using COMMAND;
using UnityEngine;
using UnityEngine.UI;

public enum Phases
{
    Introduction,
    Base,
    Elite,
    Superior,
    End
};

public class Enemy : SpaceshipBase
{
    public Phases phase;
    public GameObject projectilePrefab;
    protected Transform player;
    protected Transform enemy;
    protected float nextFire;
    [SerializeField] protected float fireSpeed = 100f;
    [SerializeField] protected float fireRate = 1f;
    [SerializeField] protected List<GameObject> shootOrigins;
    Command shootCommand;

    [Header("UI")]
    [SerializeField] private Image healthbarSprite;
    [Header("VFX")]
    [SerializeField] private GameObject explosionPrefab;
    //ACTIONS
    public static event Action EnemyDeath;
    [Header("Wave INFO")]
    [SerializeField] private WaveController parentWave; //Referencing wave controller

    private void Start()
    {
        shootCommand = new ShootCommand(fireSpeed, fireRate, projectilePrefab, shootOrigins, nextFire);

        CurrentHealth = HealthBar.Count;
        MaxHealth = HealthBar.Count;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = transform;
        phase = Phases.Base;
    }

    private void Update()
    {
        Attack();
    }

    public virtual void Attack()
    {
        enemy.LookAt(player);
        shootCommand.Execute();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Lasers"))
        {
            Pull();

            if (CurrentHealth <= 0)
            {
                GameObject explosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
                Destroy(explosion, 1f);
                Destroy(gameObject);
                EnemyDeath.Invoke();
            }
        }

    }
    private void OnDestroy()
    {
        if (parentWave != null)
            parentWave.enemies.Remove(gameObject);
    }
}

