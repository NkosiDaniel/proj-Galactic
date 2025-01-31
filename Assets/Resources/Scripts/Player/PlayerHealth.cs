using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] List<GameObject> healthBar = new List<GameObject>();
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject player;
    private int count;
    private static int maxCount;
    private int maxPotential = 6;

    public static event Action PlayerDied;

    private void Start()
    {
        PlayerDied += Explode;

        maxCount = maxPotential;
        count = maxPotential;
    }

    public void Push()
    {
        if (count < maxCount)
        {
            healthBar[count].SetActive(true);
            count++;
        }
    }

    public void SetMaxHealth()
    {
        for ( ; count < maxCount; count++)
        {
            healthBar[count].SetActive(true);
        }
    }

    public void IncreaseMaximum() 
    {
        if(maxPotential <= 12) 
        {
            maxPotential++;
            maxCount = maxPotential;
            count = maxCount;
            healthBar[maxPotential-1].SetActive(true);
        }
    }

    public void DecreaseMaximum() 
    {

    }
    public void Pull()
    {
        if (count > 0)
        {
            healthBar[count - 1].SetActive(false);
            count--;
        }

        if (count <= 0)
        {
            PlayerDied.Invoke();
        }
    }

    public void Explode()
    {
        if (count <= 0)
        {
            GameObject explosion = Instantiate(explosionPrefab, player.transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            player.GetComponent<MeshRenderer>().enabled = false;
            Debug.Log("Has run!");
        }
    }



}
