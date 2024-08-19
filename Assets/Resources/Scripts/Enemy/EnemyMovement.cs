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

   private Enemy enemyController;

   private Transform player;
   private Transform enemy;

   private Rigidbody rigidbody;
   private Vector3 targetDirection;
   private float changeDirectionCooldown;

   private Vector3 distance;
   private float distanceFrom;

   private Boolean isShooting = false;

   private Vector3 currentVelocity;

   private void Awake() 
   {
        rigidbody = GetComponent<Rigidbody>();
        targetDirection = transform.up;
        player = FindAnyObjectByType<PlayerController>().transform;
        enemy = this.transform;
        enemyController = GetComponent<Enemy>();
   }

   private void FixedUpdate() 
   {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
   }

    private void UpdateTargetDirection() 
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
    }

    private void HandleRandomDirectionChange()
    {
        changeDirectionCooldown -= Time.deltaTime;

        if(changeDirectionCooldown <= 0) 
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            targetDirection = rotation * targetDirection;

            changeDirectionCooldown = Random.Range(1f, 5f);
        }
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
        if(distanceFrom < targetDistance - 10) 
        {
            enemyController.Attack();
        }
        else
            isShooting = false;
    }

    private void RotateTowardsTarget() 
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        rigidbody.MoveRotation(rotation);
    }

    private void SetVelocity() 
    {
        rigidbody.velocity = transform.up * speed;
    }
}
