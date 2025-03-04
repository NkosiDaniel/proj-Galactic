using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] waves;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private TMP_Text waveText;
    private int waveIndex;
    public delegate void OnZeroWaves();
    public static event OnZeroWaves LastWave;

    private void Start()
    {
        waveText.text = "Wave - " + (waveIndex + 1);
        SpawnWave();
    }

    private void SpawnWave()
    {
        if (waveIndex >= waves.Length) return;

        GameObject waveInstance = Instantiate(waves[waveIndex], spawnPoints[0].transform.position, quaternion.identity);
        WaveController waveController = waveInstance.GetComponent<WaveController>();
        waveText.text = "Wave - " + (waveIndex + 1);

        if (waveController != null)
            waveController.onWaveDestroyed += HandleWaveDestroyed;
    } 

    private void HandleWaveDestroyed(WaveController wave) 
    {
        if(waveIndex >= waves.Length) LastWave?.Invoke();

        wave.onWaveDestroyed -= HandleWaveDestroyed; //Cleaning up the listener
        waveIndex++;
        SpawnWave();
    }

}

