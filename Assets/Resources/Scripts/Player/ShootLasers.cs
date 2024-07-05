using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootLasers : MonoBehaviour
{
    [SerializeField] private float fireSpeed;
    [SerializeField] private List<GameObject> shooters;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float fireRate;
    private float nextFire;


    // Update is called once per frame
    void Update()
    {
        //Will instantiate objects with force each frame
        //Will delete them after a few seconds so the game doesn't experience frame loss and performance issues
        OnShoot();
    }

    //
    public void OnShoot()
    {
            if (Time.time > nextFire)
            {
                foreach (GameObject s in shooters)
                {
                    nextFire = Time.time + fireRate;
                    GameObject laser = Instantiate(laserPrefab, s.transform.position, s.transform.rotation);
                    laser.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, -fireSpeed));
                    laser.AddComponent<OnEnemyAtk>();
                    FindObjectOfType<AudioManager>().PlaySound("LaserShoot");
                    Destroy(laser, 2);
                }
            }
    }

    public void UltimateAtk()
    {
        //Will trigger from player input
    }
}
