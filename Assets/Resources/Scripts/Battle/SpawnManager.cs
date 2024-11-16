using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] waves;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private float waveRate;
    private bool waveIsDone = true;



    private void Update()
    {
        if (waveIsDone)
            StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        waveIsDone = false;

        for (int i = 0; i <= waves.Length; i++)
        {
            GameObject waveClone = Instantiate(waves[i], spawnPoints[0].transform.position, Quaternion.identity);

            yield return new WaitForSeconds(waveRate);

            if (i == waves.Length - 1) 
            {
                Debug.Log("Coroutine has stopped running!");
                waveIsDone = false;
                StopCoroutine(SpawnWaves());
            }


        }

        waveIsDone = true;
    }

}
