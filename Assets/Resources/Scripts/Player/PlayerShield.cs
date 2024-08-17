using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private float shieldAmount;
    private float shieldCooldown;
    private ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public GameObject explosionPrefab;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Lasers"))
        {
            int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

            Destroy(other);
            GameObject explosion = Instantiate(explosionPrefab, collisionEvents[0].intersection, Quaternion.identity);

            ParticleSystem p = explosion.GetComponent<ParticleSystem>();
            var pmain = p.main;
        }
    }
}
