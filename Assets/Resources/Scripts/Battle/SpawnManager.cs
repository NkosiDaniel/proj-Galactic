using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] waves;
    [SerializeField] private GameObject[] spawnPoints;
    private int waveIndex;

    private void Start()
    {
        SpawnWave();
    }

    private void SpawnWave()
    {
        if (waveIndex >= waves.Length) return;

        GameObject waveInstance = Instantiate(waves[waveIndex], spawnPoints[0].transform.position, quaternion.identity);
        WaveController waveController = waveInstance.GetComponent<WaveController>();

        if (waveController != null)
            waveController.onWaveDestroyed += HandleWaveDestroyed;
    }

    private void HandleWaveDestroyed(WaveController wave) 
    {
        wave.onWaveDestroyed -= HandleWaveDestroyed; //Cleaning up the listener
        waveIndex++;
        SpawnWave();
    }

}

