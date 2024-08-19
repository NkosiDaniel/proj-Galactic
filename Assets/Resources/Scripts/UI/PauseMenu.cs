using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using COMMAND;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private bool isActive = false;
    private OpenCommand pauseCommand;

    void Start()
    {
        pauseCommand = new OpenCommand(pauseMenu, isActive);
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

}
