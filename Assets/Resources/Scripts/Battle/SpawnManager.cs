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
        if(waveIsDone)
            StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves() 
    {
        waveIsDone = false;

        foreach(var wave in waves) 
        {
            GameObject waveClone = Instantiate(wave, spawnPoints[0].transform.position, Quaternion.identity);

            yield return new WaitForSeconds(waveRate);
        }

        waveIsDone = true;
    }

}
