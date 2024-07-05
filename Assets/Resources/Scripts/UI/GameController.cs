using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TMP_Text overText;
    [SerializeField] GameObject boss;

    private void Start()
    {
        
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ReturnButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void WinScreen()
    {
        gameOverScreen.SetActive(true);
        overText.text = "You win!";
    }

    public void DeathScreen() 
    {
        gameOverScreen.SetActive(true);
        overText.text = "You lose!";
    }
}
