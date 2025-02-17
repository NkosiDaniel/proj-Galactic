using System.Collections;
using System.Collections.Generic;
using COMMAND;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TarotMenu : MonoBehaviour
{
    [SerializeField] GameObject tarotMenu;
    [SerializeField] Button confirmButton;
    [SerializeField] Button cancelButton;
    [SerializeField] TMP_Text statusText;
    [SerializeField] TMP_Text statusText2;
    [SerializeField] TMP_Text costText;
    [SerializeField] TMP_Text costText2;
    private Command tarotCommand;
    private PlayerControls playerControls;
    private int cost;
    private ScoreManager scoreManager;
    private TarotSystem tarotSystem;

    void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Gameplay.TarotMenu.performed += ctx => ShowTarotMenu();
    }

    void OnEnable()
    {
        playerControls.Gameplay.Enable();
    }

    void OnDisable()
    {
        playerControls.Gameplay.Disable();
    }

    void Start()
    {
        tarotCommand = new OpenCommand(tarotMenu);

        cost = 400;

        scoreManager = ScoreManager.Instance;

        tarotMenu.SetActive(false);
    }

    public void ShowTarotMenu()
    {
        tarotCommand.Execute();

        costText.text = "Cost: " + cost;
        costText2.text = "Cost: " + cost;
    }

    public void ConfirmButton()
    {
        if (scoreManager.score - cost < 0)
            return;
        else
        {
            confirmButton.gameObject.SetActive(false);
            cancelButton.gameObject.SetActive(false);

            tarotSystem.Instance().StartReading();

            cost += 50;
        }
    }

    public void CancelButton()
    {
        tarotCommand.Execute();
    }
}
