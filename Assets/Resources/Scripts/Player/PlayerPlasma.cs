using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerPlasma : MonoBehaviour
{
    [SerializeField] List<GameObject> plasmaBar = new List<GameObject>();
    [SerializeField] UltimateAttack ultimateAttack;
    [SerializeField] TMP_Text ultMoveText;
    private int plasmaCount;
    private int maxPlasma;
    private float cooldownMax;
    private float cooldownTimer;

    public void Start()
    {
        Enemy.EnemyDeath += Push;

        plasmaCount = plasmaBar.Count;
        maxPlasma = plasmaBar.Count;

        cooldownMax = ultimateAttack.CooldownTime;
        cooldownTimer = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && cooldownTimer < 0)
        {
            ActivateUltimate();
            Camera.main.DOShakePosition(2f, 5f, 10, 90f, true);
            cooldownTimer = cooldownMax;
            
            ultMoveText.text = ultimateAttack.Name;
            ultMoveText.gameObject.SetActive(true);
            ultMoveText.DOFade(0f, 2f);
        }
        cooldownTimer -= Time.deltaTime;
    }

    private void ActivateUltimate()
    {
        if (ultimateAttack != null)
        {
            if (ultimateAttack.ActivationCost <= plasmaCount)
            {
                ultMoveText.gameObject.SetActive(false);
                ultMoveText.alpha = 1f;
                
                Pull(ultimateAttack.ActivationCost);

                BeamUlt();

            }
        }
    }

    private void BeamUlt()
    {
        GameObject beam = Instantiate(ultimateAttack.beamProjectile, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 25), Quaternion.identity);
        Destroy(beam, 5);
    }

    public void Pull(int value)
    {
        for (int i = 0; i < value; i++)
        {
            plasmaBar[plasmaCount - 1].SetActive(false);
            plasmaCount--;
        }
    }

    public void Push()
    {
        plasmaBar[plasmaCount - 1].SetActive(true);
        plasmaCount++;
    }

}
