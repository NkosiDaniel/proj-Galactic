using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhilautiaController : Enemy
{
    [SerializeField] private List<GameObject> healingSet;
    private bool threshold = true;

    void Start()
    {
        CurrentHealth = HealthBar.Count;
        MaxHealth = HealthBar.Count;

        healingSet = new List<GameObject>();
        StartCoroutine(Heal());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (!healingSet.Contains(other.gameObject))
                healingSet.Add(other.gameObject);
        }
        if (healingSet.Count > 0 && threshold)
        {
            StartCoroutine(Heal());
            threshold = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            healingSet.Remove(other.gameObject);
        }
        if (healingSet.Count <= 0 && !threshold)
        {
            StopCoroutine(Heal());
            threshold = true;
        }
    }

    private IEnumerator Heal()
    {
        Debug.Log("Start Coroutine!");
        while (true)
        {
            foreach (GameObject i in healingSet)
            {
                Debug.Log(i);
                i.GetComponent<Enemy>().Push();
            }
            yield return new WaitForSeconds(1f);
        }
    }
    public override void Attack()
    {

    }
}