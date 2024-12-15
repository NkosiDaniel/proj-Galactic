using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float setTime;
    private float timeScale = 1f;

    private void Update() 
    {
        setTime -= Time.deltaTime * timeScale;

    }

    private void UpdateTimer() 
    {
        int hours = Mathf.FloorToInt(setTime / 3600f);
    }
}
