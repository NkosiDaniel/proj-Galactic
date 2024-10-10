using System.Collections;
using System.Collections.Generic;
using COMMAND;
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
    [SerializeField] private TMP_Text statusScreenTxt;
    [SerializeField] private TMP_Text nextLvlTxt;
    [SerializeField] private TMP_Text returnTxt;

    [Header("Prefabs")]
    [SerializeField] private GameObject theStars;

    [Header("Instantiate Info")]
    [SerializeField] private List<GameObject> spawnPoints;
    private float instantiateTimer = 10f;

    //Commands

    private void Start()
    {
        PlayerHealth.PlayerDied += ShowDefeatScreen;

    }
    #region TIME API
    private void Update()
    {
        setTime -= Time.deltaTime * timeScale;
        instantiateTimer -= Time.deltaTime;

        if (instantiateTimer <= 0)
        {
            SpawnEnemy();
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
            ShowVictoryScreen();
        }
    }
    #endregion

    #region EVENTS API
    private void SpawnEnemy()
    {
        if(spawnPoints.Count > 0) {
        Transform randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Count)].transform;
        Instantiate(theStars, randomSpawn.position, Quaternion.identity);
        }
    }
    #endregion

    #region UI MANAGER
    public void ShowVictoryScreen() 
    {
        Time.timeScale = 0f;
        statusScreen.SetActive(true);
        nextLvlTxt.gameObject.SetActive(true);

        statusScreenTxt.text = "Victory!";
    }

    public void ShowDefeatScreen() 
    {
        Time.timeScale = 0f;
        statusScreen.SetActive(true);
        nextLvlTxt.gameObject.SetActive(false);

        statusScreenTxt.text = "Defeat!";
    }
    #endregion
}
