using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V3PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    private float horizontal;
    private Rigidbody rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        horizontal = Input.GetAxis("Horizontal");
        MoveX(speed);
    }

    private void MoveX(float speed) 
    {
        Vector3 force = transform.right * -speed * horizontal;
        transform.position += force * Time.deltaTime;
    }


}
