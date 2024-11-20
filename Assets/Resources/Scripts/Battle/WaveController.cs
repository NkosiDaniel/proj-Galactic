using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public List<GameObject> enemies;
    //Using delegates and events (subscription based concepts)
    public delegate void WaveDestroyed(WaveController wave);
    public event WaveDestroyed onWaveDestroyed;

    void Start() 
    {
        if(enemies == null || enemies.Count == 0) 
        {
            enemies = new List<GameObject>();
            foreach(Transform child in transform) 
            {
                enemies.Add(child.gameObject);
            }
        }
    }
    void Update() 
    {
        //Checking if all enemies are destroyed or inactive
        if(enemies.TrueForAll(enemies => enemies == null || !enemies.activeInHierarchy)) 
        {
            HandleWaveDestroyed();
        }
    }

    private void HandleWaveDestroyed() 
    {
        onWaveDestroyed?.Invoke(this); //Notify listeners to this event
        Destroy(gameObject);
    }
}
