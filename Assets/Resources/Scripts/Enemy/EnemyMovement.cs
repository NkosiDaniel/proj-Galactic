using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
   [SerializeField] float speed;
   [SerializeField] float rotationSpeed;
   [SerializeField] float targetDistance;

   private Transform player;
   private Transform enemy;

   private Rigidbody rigidbody;
   private Vector3 targetDirection;
   private float changeDirectionCooldown;

   private Vector3 distance;
   private float distanceFrom;

   private Vector3 currentVelocity;

   private void Awake() 
   {
        rigidbody = GetComponent<Rigidbody>();
        targetDirection = transform.up;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = this.transform;
   }

   private void Update() 
   {
        UpdateTargetDirection();
   }

    private void UpdateTargetDirection() 
    {
        HandlePlayerTargeting();
    }

    private void HandlePlayerTargeting()
    {
        distance = (enemy.position - player.position);
        distance.y = 0;
        distanceFrom = distance.magnitude;
        distance /= distanceFrom;

        if(distanceFrom < targetDistance) 
        {
            transform.position = Vector3.SmoothDamp(enemy.position, player.position, ref currentVelocity , 0.5f, 5f);
        }
    }
}
