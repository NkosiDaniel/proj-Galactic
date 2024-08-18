using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private bool isActive = false;

    void Update()
    {
        ShowPauseMenu();
    }
    public void ShowPauseMenu()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.M))
        {
            isActive = !isActive;
            if (isActive == true)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
            pauseMenu.SetActive(isActive);

        }
    }

}
