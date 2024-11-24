using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private float score;
    [SerializeField] private TMP_Text scoreText;

    public void UpdateScore(float value) 
    {
        score += value;
        scoreText.text = "Score - " + score;
    }
}
