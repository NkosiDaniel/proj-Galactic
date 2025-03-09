using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Tarot Card", menuName = "Cards/Card")]
public class TarotCard : ScriptableObject
{
    //Rarity coefficient
    [SerializeField] private float rarityCoeff;
    [SerializeField] private bool rerollable;
    [SerializeField] private TarotAbility ability;
    [SerializeField] private Sprite tarotIllustration;
    private bool quickExecute;

    private void Execute()
    {
        ability.Execute();
        TarotSystem.Instance.Draws -= 1;
    }

    public float RC { get { return rarityCoeff; } }
    public bool IsRerollable { get { return rerollable; } }
    public Sprite TarotImage { get {return tarotIllustration; } }
}
