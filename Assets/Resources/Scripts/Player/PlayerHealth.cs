using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] List<GameObject> healthBar = new List<GameObject>();
    private int count;
    private int maxCount;

    private void Start()
    {
        maxCount = healthBar.Count;
        count = healthBar.Count;
    }

    public void Push()
    {
        if (count < maxCount)
        {
            healthBar[count].SetActive(true);
            count++;
        }
    }

    public void Pull()
    {
        if(count > 0) 
        {
            healthBar[count-1].SetActive(false);
            count--;
        }
    }
}
