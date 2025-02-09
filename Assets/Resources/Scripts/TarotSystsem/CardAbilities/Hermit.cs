using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Tarot Ability", menuName = "Abilities/Hermit")]
public class Hermit : TarotAbility 
{
    private TarotSystem tarotSystem;
    override
    public void Execute()
    {
        tarotSystem.Instance().Draws += 2;
    }
}
