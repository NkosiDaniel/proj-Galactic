using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotCardHolder : MonoBehaviour
{
    private TarotCard tarotCard;

    public TarotCard CardInfo {get { return tarotCard;} set { tarotCard = value; } }
}
