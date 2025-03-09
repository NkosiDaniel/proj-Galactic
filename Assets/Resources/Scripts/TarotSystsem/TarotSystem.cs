using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TarotSystem : MonoBehaviour
{
    private enum ReadingState
    {
        START,
        ACTIVE,
        END,
        INACTIVE
    }
    [SerializeField] private List<TarotCard> cardList; //Global list of cards that is sent to every new reading
    [SerializeField] private List<GameObject> gameCards; //The cards in-game that will recieve data
    [SerializeField] private GameObject readingScreen;
    private List<TarotCard> modList; //This will be sent over to a new reading if this list is populated
    private ReadingState readingState; //Will control the flow of the reading
    public static TarotSystem Instance { get; private set; }
    private int draws;
    private TarotReading currentReading;

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
        draws = 1;
        readingState = ReadingState.INACTIVE;
    }
    //All the state logic is decided in this Update block
    private void Update()
    {
        if (readingState == ReadingState.START)
        {
            currentReading = new TarotReading(cardList, 3);
            readingScreen.SetActive(true);
            readingState = ReadingState.ACTIVE;
            ReadingSetup();
        }

        if (readingState == ReadingState.ACTIVE)
        {
            if (draws == 0)
            {
                readingState = ReadingState.END;
            }
        }

        if (readingState == ReadingState.END)
        {
            readingScreen.SetActive(false);
            readingState = ReadingState.INACTIVE;
        }
    }

    public void StartReading()
    {
        readingState = ReadingState.START;
    }

    private void ReadingSetup()
    {
        GameObject[] cards = gameCards.ToArray();
        TarotCard[] data = currentReading.AvailableSelection.ToArray();

        for (int i = 0; i < gameCards.Count; i++)
        {
            cards[i].GetComponent<TarotCardHolder>().CardInfo = data[i];
            cards[i].GetComponent<Image>().sprite = data[i].TarotImage;
        }
    }

    public int Draws { get { return draws; } set { draws = value; } }

}
