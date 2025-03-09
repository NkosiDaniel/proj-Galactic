using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // This is the Singleton instance
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;
    public float score;

    // score multiplier variable
    public float scoreMultiplier = 1.0f;

    private void Awake()
    {
        // Implement Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keeps this object across scenes
        }
    }

    private void Start() 
    {
        scoreText.text = "Score - " + score;
    }
    public void UpdateScore(float value)
    {
        // Adjust score based on multiplier
        score += value * scoreMultiplier;
        scoreText.text = "Score - " + score; // Display score with 2 decimal places
    }
}
