using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] List<GameObject> healthBar = new List<GameObject>();
    private int count;
    private int maxCount;

    [SerializeField] private Image healthbarSprite;

    private Camera cam;
    private void Start()
    {
        maxCount = healthBar.Count;
        count = healthBar.Count;

        cam = Camera.main;
    }

    public void Push()
    {
        if (count < maxCount)
        {
            healthBar[count].SetActive(true);
            count++;
        }
    }

    public void Pull()
    {
        if (count > 0)
        {
            healthBar[count - 1].SetActive(false);
            count--;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Lasers"))
        {
            Pull();
            if (count <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
