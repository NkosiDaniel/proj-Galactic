using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    [SerializeField] private Addon addon;

    private void Awake()
    {
        FindObjectOfType<AudioManager>().PlaySound(addon.ShootSound);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (addon.PlayerAddon)
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                if (addon.ExpPrefab != null && other.gameObject.tag != this.gameObject.tag)
                {
                    GameObject explosion = Instantiate(addon.ExpPrefab, this.transform);
                    Destroy(explosion, 1.5f);
                }
                Destroy(this);
            }
        }
        else
            if (addon.ExpPrefab != null && other.gameObject.tag != this.gameObject.tag)
        {
            GameObject explosion = Instantiate(addon.ExpPrefab, this.transform);
            Destroy(explosion, 1.5f);
            Destroy(this);
        }
    }
}
