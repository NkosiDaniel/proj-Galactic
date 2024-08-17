using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBase : MonoBehaviour
{
    //Stats for each ship type
    [SerializeField] string name;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] int health;
    [SerializeField] int defense;
    [SerializeField] int speed;


    //Encapsulation; getter methods for each serialized field
    public string Name { get{return name;} }
    public string Description { get{return description;} }
    public int Health { get{return health;} }
    public int Defense { get{return defense;} }
    public int Speed { get{return speed;} }
    
        
    }

