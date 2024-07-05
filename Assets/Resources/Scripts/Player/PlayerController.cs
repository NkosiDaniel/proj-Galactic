using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    public float moveSpeed = 10;
    public float maxVelocity = 3;
    public float maxTurnSpeed = 0.1f;
    private Rigidbody rb;
    private float moveX;
    private float moveY;

    #region 
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

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
        Vector3 force = -transform.forward * amount * moveSpeed;
        rb.AddRelativeForce(0, 0, amount * moveSpeed);
    }

    private void ClampMovement() 
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector3(x, transform.position.y, y);
    }

    private void Rotate(Transform t, float amount) 
    {
        t.Rotate(0, amount, 0);
    }

    #endregion MOVEMENT API
}
