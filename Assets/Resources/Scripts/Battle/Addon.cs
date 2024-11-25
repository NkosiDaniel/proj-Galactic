using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile Addon", menuName = "Add-On")]
public class Addon : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private string shootSound;
    [SerializeField] private string explodeSound;
    [SerializeField] private bool playerAddon;

    public int Damage { get { return damage; } }
    public GameObject ExpPrefab {get { return explosionPrefab; }}
    public string ShootSound { get { return shootSound;}}
    public string ExpSound { get { return explodeSound;}}
    public bool PlayerAddon { get { return playerAddon;}}

}
