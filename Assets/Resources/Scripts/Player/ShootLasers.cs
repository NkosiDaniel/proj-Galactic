using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using COMMAND;
using Unity.VisualScripting;

public class ShootLasers : MonoBehaviour
{
    [Header("Shooter Variables")]
    [SerializeField] float fireSpeed;
    [SerializeField] List<GameObject> shooters;
    [SerializeField] float fireRate;
    [SerializeField] GameObject laserPrefab;

    private float nextFire;
    private Command shootCommand;
    private PlayerControls controls;

    void Awake() 
    {
        controls = new PlayerControls();
        controls.Gameplay.Shoot.performed += ctx => shootCommand.Execute();
    }

    void OnEnable() 
    {
        controls.Gameplay.Enable();
    }

    void OnDisable() 
    {
        controls.Gameplay.Disable();
    }

    void Start() 
    {
        shootCommand = new ShootCommand(fireSpeed, fireRate, laserPrefab, shooters, nextFire);
    }

    void Update() 
    {
        OnShoot();
    }

    public void OnShoot() 
    {
        if(Input.GetButtonDown("Fire1")) 
        {
            shootCommand.Execute();
        }
    }
}
