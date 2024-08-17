using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    
    public Camera mainCamera;
    public GameObject laserPrefab;

    [Header("Movement Variables")]
    [SerializeField] float moveSpeed = 1;
    [SerializeField]float maxVelocity = 3;
    [SerializeField]float maxTurnSpeed = 0.01f;

    [Header("Shooter Variables")]
    [SerializeField] float fireSpeed;
    [SerializeField] List<GameObject> shooters;
    [SerializeField] float fireRate;
    
    private Rigidbody rb;
    private float moveX;
    private float moveY;
    private float nextFire;

    #region MONOBEHAVIOUR API
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        OnShoot();
        Rotate(transform, moveX * maxTurnSpeed);
        /*
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
         mousePosition += ((Vector3)transform.position - mousePosition).normalized * minDist; 
         mousePosition.y = 1;

         direction = mousePosition - transform.position;
         transform.position = Vector3.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, moveSpeed);
         float targetAngle = Vector3.SignedAngle(Vector3.right, direction, Vector3.up);
         angle = Mathf.SmoothDampAngle(angle, targetAngle, ref currVelocity, smoothTime, maxTurnSpeed);
         transform.eulerAngles = new Vector3 (0, angle, 0); */
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        BoostForward(moveY);
    }

    #endregion
   
   #region MOVEMENT API
    private void BoostForward(float amount) 
    {
        Vector3 force = transform.forward * amount * moveSpeed;
        rb.AddRelativeForce(0, 0, amount * -moveSpeed, ForceMode.VelocityChange);
    }
    /// <summary>
    /// Limits the speed of the Rigidbody's X and Y speeds.
    /// </summary>
    private void ClampMovement() 
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector3(x, transform.position.y, y);
    }
    /// <summary>
    /// Uses the Rotate method from MonoBehaviour to rotate a transform by its Y transform.
    /// </summary>
    /// <param name="t"></param>
    /// <param name="amount"></param>
    private void Rotate(Transform t, float amount) 
    {
        t.Rotate(0, amount, 0);
    }

    #endregion MOVEMENT API

    #region ATTACK API
    /// <summary>
    /// Instantiates laser prefabs to be fired towards a target based on fire rate.
    /// </summary>
    public void OnShoot() 
    {
        if(Input.GetKey(KeyCode.Space)) 
        {
            if(Time.time > nextFire) 
            {
                foreach(GameObject s in shooters) 
                {
                    nextFire = Time.time + fireRate;
                    GameObject laser = Instantiate(laserPrefab, s.transform.position, s.transform.rotation);
                    laser.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, -fireSpeed));
                    FindObjectOfType<AudioManager>().PlaySound("LaserShoot");
                    Destroy(laser, 2);

                }
            }
        }
    }

    public void UltimateAttack()
    {

     }
    #endregion ATTACK API
}
