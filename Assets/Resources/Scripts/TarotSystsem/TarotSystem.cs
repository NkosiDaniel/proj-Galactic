using System.Collections;
using System.Collections.Generic;
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
    private static TarotSystem instance;
    private int draws;

    private void Start()
    {
        instance = this;
        draws = 1;
    }

    private void Update()
    {
        if (readingState == ReadingState.START)
        {
            TarotReading newReading = new TarotReading(cardList);
            readingScreen.SetActive(true);
            readingState = ReadingState.ACTIVE;
        }

        if (readingState == ReadingState.ACTIVE)
        {
            if(draws == 0) 
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

    private void ReadingSetup(TarotReading reading) 
    {  
        GameObject[] cards = gameCards.ToArray();
        TarotCard[] data = reading.AvailableSelection.ToArray();

        for(int i = 0; i < gameCards.Count; i++) 
        {
           cards[i].GetComponent<TarotCardHolder>().CardInfo = data[i];
           cards[i].GetComponent<Image>().sprite = data[i].TarotImage;
        }
    }   
    public TarotSystem Instance()
    {
        if (instance == null)
            instance = new TarotSystem();
        return instance;
    }

    public int Draws { get { return draws; } set { draws = value; } }

}
