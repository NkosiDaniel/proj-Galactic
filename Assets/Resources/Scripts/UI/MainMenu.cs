using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    private void Start() {
        FindObjectOfType<AudioManager>().PlaySound("Theme");
    }

    public void Play() 
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonClick");
    }
}
