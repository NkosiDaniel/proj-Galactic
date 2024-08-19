using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    [Header("Timer Info")]
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float setTime;
    public float timeScale = 1f;

    [Header("Game UI")]
    [SerializeField] private GameObject statusScreen;

    [Header("Prefabs")]
    [SerializeField] private GameObject theStars;
    
    [Header("Instantiate Info")]
    [SerializeField] private List<GameObject> spawnPoints;


    private float instantiateTimer = 5f;


    private void Update()
    {
        setTime -= Time.deltaTime * timeScale;
        instantiateTimer -= Time.deltaTime;

        if (instantiateTimer <= 0) {
            //SpawnEnemy();
            instantiateTimer = 5;
        }


        UpdateTimer();

    }

    private void UpdateTimer()
    {
        int hours = Mathf.FloorToInt(setTime / 3600f);
        int minutes = Mathf.FloorToInt((setTime - hours * 3000f) / 60f);
        int seconds = Mathf.FloorToInt(setTime - hours * 3600f - (minutes * 60f));

        string clockString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = clockString;

        CheckTime();
    }

    private void CheckTime()
    {
        if (setTime <= 0f)
        {
            Time.timeScale = 0f;
            statusScreen.SetActive(true);
        }
    }

    /*private void SpawnEnemy()
    {
       Transform randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Count)].transform;
       Instantiate(theStars, randomSpawn.position, Quaternion.identity);
    }*/

}
