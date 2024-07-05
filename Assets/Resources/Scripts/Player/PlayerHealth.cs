using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    public static event Action OnPlayerDeath;
    int HP;

    // Start is called before the first frame update
    void Awake()
    {
        HP = 3;
        SetHP(HP);
    }

    public void SetHP(int hp)
    {
        var sequence = DOTween.Sequence();
        //3 Hearts
        if (hp == 3)
        {
            foreach (Image h in hearts)
            {
                sequence.Append(h.DOColor(Color.white, 0.1f));
            }
        }
        //2 Hearts
        if (hp == 2)
            sequence.Append(hearts[0].DOColor(Color.black, 0.1f));
        //1 Heart
        if (hp == 1)
        {
            sequence.Append(hearts[0].DOColor(Color.black, 0.1f));
            sequence.Append(hearts[1].DOColor(Color.black, 0.1f));  
        }
        //No Hearts
        if (hp == 0 || hp < 0)
        {
            foreach (Image h in hearts)
            {
                sequence.Append(h.DOColor(Color.black, 0.1f));
            }

            Destroy(gameObject);
            FindAnyObjectByType<AudioManager>().PlaySound("DestroyShip");
            
        }

    }

    public void TakeDamage()
    {
        HP -= 1;

        if(HP == 0 || HP < 0) 
        {
           OnPlayerDeath?.Invoke();
        }
        SetHP(HP);
    }
}
