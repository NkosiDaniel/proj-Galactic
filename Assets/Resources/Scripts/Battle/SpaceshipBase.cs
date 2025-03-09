using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBase : MonoBehaviour
{
    //Stats for each ship type
    [SerializeField] string spaceShipName;
    [TextArea]
    [SerializeField] string description;

    [Header("Health Information")]
    [SerializeField] List<GameObject> healthBar = new List<GameObject>();
    private int count;
    private int maxCount;

    //ADD HEALTH
    public void Push()
    {
        if (count < maxCount)
        {
            healthBar[count].SetActive(true);
            count++;
        }
    }

    //SUBTRACT HEALTH
    public virtual void Pull(int value = 1)
    {
        for (int i = 0; i < value; i++)
        {
            if (count > 0)
            {
                healthBar[count - 1].SetActive(false);
                count--;
            }
        }
    }
    //Encapsulation; getter methods for each serialized field
    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public List<GameObject> HealthBar { get { return healthBar; } }
    public int CurrentHealth { get { return count; } set { count = value; } }
    public int MaxHealth { get { return maxCount; } set { maxCount = value; } }

}

