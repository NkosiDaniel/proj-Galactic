using System.Collections;
using System.Collections.Generic;
using COMMAND;
using UnityEngine;

enum PositionStates
{
    Stable,
    Center,
    Right,
    Left
}
public class V2PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed;
    [Header("Player Positions")]
    [SerializeField] private GameObject leftPoint;
    [SerializeField] private GameObject rightPoint;
    [SerializeField] private GameObject centerPoint;
    //Player INPUT
    private float horizontal;
    //State Pointers
    private PositionStates positionState;
    private PositionStates currentPointer;
    //Time Variables
    private float timeDuration = 0.25f;
    private float timer;
    private bool canMove = true;
    [Header("Shooter Variables")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float fireSpeed;
    [SerializeField] List<GameObject> shooters;
    [SerializeField] float fireRate;

    private Command shootCommand;

    #region MONOBEHAVIOUR
    void Start()
    {
        positionState = PositionStates.Stable;
        currentPointer = PositionStates.Center;

        shootCommand = new ShootCommand(fireSpeed, fireRate, laserPrefab, shooters);
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        timer -= Time.deltaTime;

        canMove = timer >= 0 ? false : true;


        Debug.Log("Timer is at: " + timer);
        Debug.Log(canMove);

        OnShoot();
    }

    void LateUpdate()
    {
        StateManipulator();
    }
    #endregion MONOBEHAVIOUR

    #region MOVEMENT API
    public void StateManipulator()
    {
        if (currentPointer == PositionStates.Left && canMove)
        {
            if (horizontal > 0)
            {
                currentPointer = PositionStates.Center;
                timer = timeDuration;
            }
        }

        else if (currentPointer == PositionStates.Center && canMove)
        {
            if (horizontal > 0)
            {
                currentPointer = PositionStates.Right;
                timer = timeDuration;
            }
            if (horizontal < 0)
            {
                currentPointer = PositionStates.Left;
                timer = timeDuration;
            }
        }

        else if (currentPointer == PositionStates.Right && canMove)
        {
            if (horizontal < 0)
            {
                currentPointer = PositionStates.Center;
                timer = timeDuration;
            }
        }
        positionState = currentPointer;
        StateExecutor();
    }

    public void StateExecutor()
    {
        if (positionState == PositionStates.Left)
        {
            this.transform.position = Vector3.Lerp(transform.position, leftPoint.transform.position, moveSpeed);
            Debug.Log("Player is on the Left!");
        }

        else if (positionState == PositionStates.Right)
        {
            this.transform.position = Vector3.Lerp(transform.position, rightPoint.transform.position, moveSpeed);
            Debug.Log("Player is on the Right!");
        }
        else if (positionState == PositionStates.Center)
        {
            this.transform.position = Vector3.Lerp(transform.position, centerPoint.transform.position, moveSpeed);
            Debug.Log("Player is on the Center!");

        }
        positionState = PositionStates.Stable;
    }
    #endregion MOVEMENT API

    public void OnShoot() 
    {
        if(Input.GetKey(KeyCode.Space))
            shootCommand.Execute();
    }
}