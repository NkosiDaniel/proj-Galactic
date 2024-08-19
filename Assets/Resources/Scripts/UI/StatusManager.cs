using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float setTime;

    [SerializeField] private GameObject statusScreen;
    public float timeScale = 1f;

    private void Update()
    {
        if (setTime >= 0)
            setTime -= Time.deltaTime * timeScale;

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

}
