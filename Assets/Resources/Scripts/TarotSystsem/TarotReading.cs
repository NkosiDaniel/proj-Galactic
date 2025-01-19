using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TarotReading : MonoBehaviour
{
    private List<TarotCard> cardList;
    private List<TarotCard> modList; //This is for cards that execute their effects during the next reading
    private List<TarotCard> selectedList; //This is the random generated list from the given list of tarot cards
    private int listSize; //This is the amount of cards that can be selected for a drawing

    private int draws; //The amount of times the player can choose a card

    public TarotReading(List<TarotCard> cardList, List<TarotCard> modList = null)
    {
        this.cardList = cardList;
        this.modList = modList;

        TarotCard[] tarotArray = cardList.ToArray();

        for (int i = 0; i < listSize; i++)
        {
            int randomNum = Random.Range(0, tarotArray.Length);
            TarotCard tarotCard = tarotArray[randomNum];

            float randomRarity = Random.Range(19f, 20f);
            bool rarityTest = (tarotCard.RC * randomRarity) >= 20;
            if (rarityTest == true)
            {
                selectedList.Add(tarotCard);
                if (!tarotCard.IsRerollable)
                {
                    tarotArray[randomNum] = null;
                }
            }
        }
    }

    public List<TarotCard> AvailableSelection { get { return selectedList; } }
}
