using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using COMMAND;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private Command pauseCommand;
    private Command optionCommand;

    void Start()
    {
        pauseCommand = new OpenCommand(pauseMenu);
    }

    void Update()
    {
        ShowPauseMenu();
    }
    public void ShowPauseMenu()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.M))
        {
            pauseCommand.Execute();
        }
    }

    public void ResumeButton() 
    {
        pauseCommand.Execute();
    }

    public void OptionsButton() 
    {
        
    }

    public void ResetButton() 
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1.0f;
    }

    public void ReturnButton() 
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }

    public void QuitButton() 
    {
        Application.Quit();
    }

}
