using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnEnemyAtk : MonoBehaviour
{
    private float attack;
    public static event Action OnEnemyHit;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.gameObject.name == "Boss")
        {
            Debug.Log($"OnTriggerEnter2D called. other's tag was {other.tag}.");
            OnEnemyHit?.Invoke();
        }
    }

    private float CalculateDamage(Collider boss)
    {
        var attack = 5f;

        float critical = 1f;
        if(UnityEngine.Random.value * 100f <= 6.25)
            critical = 1.5f;
        float modifiers = UnityEngine.Random.Range(0.75f, 1f) * critical;
            Debug.Log("Modifiers: " + modifiers);
        float a = 2 * attack * 10 / 250f;
            Debug.Log("A: " + a);
        float d = a * ((float)attack / 2);
            Debug.Log("D: " + d);
        float damage = d * modifiers;

            Debug.Log("Total Damage: " + damage);
        return damage;
    }

}
