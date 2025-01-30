using System.Collections;
using UnityEngine;


public class Hermit : TarotAbility 
{
    private TarotSystem tarotSystem;
    override
    public void Execute()
    {
        tarotSystem.Instance().Draws += 2;
    }
}
