using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Tarot Ability", menuName = "Abilities/Hermit")]
public class Hermit : TarotAbility 
{
    override
    public void Execute()
    {
        TarotSystem.Instance.Draws += 2;
    }
}
