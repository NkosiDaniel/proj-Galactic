using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private float score;
    

    public void UpdateScore(float value) 
    {
        score += value;
        scoreText.text = "Score - " + score;
    }
}
