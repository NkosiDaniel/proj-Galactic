using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private string soundToPlay;
    
    private void Awake() 
    {
        FindObjectOfType<AudioManager>().PlaySound(soundToPlay);
    }
    private void OnCollisionEnter(Collision other) {
            if(explosionPrefab != null) {
            GameObject explosion = Instantiate(explosionPrefab, this.transform);
            Destroy(explosion, 1.5f);
        }
    }
}
