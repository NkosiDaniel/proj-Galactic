using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName =  "Weapon",  menuName = "Weapons/New Laser System")]
[System.Serializable]
public class Weapon : ScriptableObject
{
   [SerializeField] private float fireSpeed;
   [SerializeField] private float fireRate;
   [SerializeField] private GameObject laserPrefab;
   [SerializeReference] private List<GameObject> shooters;
   private float nextFire;

   public float FireSpeed { get { return fireSpeed;}}
   public float FireRate { get { return fireRate;}}
   public GameObject LaserPrefab { get { return laserPrefab;}}
   public List<GameObject> Shooters { get {return shooters;}}
}
