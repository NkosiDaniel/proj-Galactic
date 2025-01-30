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
    private TarotSystem tarotSystem; //Might remove later, this references the global tarot system

    private void Execute()
    {
        ability.Execute();
        tarotSystem.Instance().Draws -= 1;
<<<<<<< HEAD
=======
        
>>>>>>> 17ba0475f3ea3c10f05ff41bd365766d5c2c1c1e
    }

    public float RC { get { return rarityCoeff; } }
    public bool IsRerollable { get { return rerollable; } }
    public Sprite TarotImage { get {return tarotIllustration; } }
}
