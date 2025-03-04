using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerPlasma : MonoBehaviour
{
    [SerializeField] List<GameObject> plasmaBar = new List<GameObject>();
    [SerializeField] UltimateAttack ultimateAttack;
    private int plasmaCount;
    private int maxPlasma;

    public void Start()
    {
        plasmaCount = plasmaBar.Count;
        maxPlasma = plasmaBar.Count;
    }

    private void ActivateUltimate()
    {
        if (ultimateAttack != null)
        {
            if (ultimateAttack.ActivationCost <= plasmaCount)
            {

            }
        }
    }

    public void DecreasePlasma(int valuet) 
    {
       
    }

}
