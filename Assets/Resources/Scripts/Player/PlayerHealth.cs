using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] List<GameObject> healthBar = new List<GameObject>();
    public GameObject healthChunk;
    private List<GameObject> healthBarCopy;
    private int currentCount = 1;
    private int maxCount = 5;

    private void Start()
    {
        healthBarCopy = healthBar;
        Push();
    }

    public void Push()
    {
        if (currentCount < maxCount)
        {
            Vector3 newPos = new Vector3(healthBarCopy[currentCount].transform.position.x + 30, 0, 0);
            Instantiate(healthChunk, newPos, Quaternion.identity);
        }
    }

    public void Pop()
    {

    }

}
