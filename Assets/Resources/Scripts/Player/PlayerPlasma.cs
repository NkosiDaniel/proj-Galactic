using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ActivateUltimate();
        }
    }

    private void ActivateUltimate()
    {
        if (ultimateAttack != null)
        {
            if (ultimateAttack.ActivationCost <= plasmaCount)
            {
                DecreasePlasma(ultimateAttack.ActivationCost);

                BeamUlt();
            }
        }
    }

    private void BeamUlt()
    {
        GameObject beam = Instantiate(ultimateAttack.beamProjectile, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 25), Quaternion.identity);
        Destroy(beam, 5);
    }

    public void DecreasePlasma(int value)
    {
        for (int i = 0; i < value; i++)
        {
            plasmaBar[plasmaCount - 1].SetActive(false);
            plasmaCount--;
        }
    }

}
