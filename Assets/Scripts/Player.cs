using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float rotationSpeed = 15f;

    public delegate void OnWalkingStatusChanged(bool isWalking);
    public static event OnWalkingStatusChanged onWalkingStatusChanged;

    public event Action onLevelClear;

    // cache
    PlayPerspective playPerspective;
    PlayerInput playerInput;

    //// constants
    //private const string GOAL_TAG = "Finish";

    // variables
    private bool wasWalking = false;
    private bool isWalking = false;

    private void Start()
    {
        playPerspective = FindObjectOfType<PlayPerspective>();
        playerInput = FindObjectOfType<PlayerInput>();

        transform.forward = FindObjectOfType<LevelManager>().level.PlayerStartDirection();
    }

    void Update()
    {
        wasWalking = isWalking;

        HandleMovement();

        if (WalkingStatusChangedSinceLastFrame())
        {

            onWalkingStatusChanged?.Invoke(isWalking);
        }
    }

    private void HandleMovement()
    {
        Vector2 inputVector = playerInput.GetMovementVector();
        Perspective perspective = playPerspective.GetCurrentPerspective();


        if (inputVector == Vector2.zero
            || perspective == Perspective.XZ_TopDown)    // let's try removing top-down movement!
        {
            isWalking = false;
            return;
        }
        isWalking = true;


        Vector3 moveDirection = Vector3.zero;

        switch (perspective)
        {
            //case Perspective.XZ_TopDown:
            //    moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
            //    break;
            case Perspective.XY_Side:
                moveDirection = new Vector3(inputVector.x, 0, 0).normalized;
                break;
            case Perspective.YZ_Side:
                moveDirection = new Vector3(0, 0, inputVector.x).normalized;
                break;
        }

        // move
        Vector3 goalPosition = transform.position + (moveDirection * moveSpeed * Time.deltaTime);
        Vector3 facingDirection = moveDirection;

        float maxDistance = .3f;
        bool isValidTarget = NavMesh.SamplePosition(goalPosition, out NavMeshHit navMeshHit, maxDistance, NavMesh.AllAreas);

        if (isValidTarget)
        {
            facingDirection = (navMeshHit.position - transform.position).normalized;

            transform.position = navMeshHit.position;
        }

        if (facingDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(facingDirection), Time.deltaTime * rotationSpeed);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == GOAL_TAG)
    //    {
    //        onLevelClear?.Invoke();
    //    }
    //}

    private bool WalkingStatusChangedSinceLastFrame()
    {
        return isWalking != wasWalking;
    }
}
