using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TopDownCameraTarget : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float snapBackSpeed = 2f;
    [SerializeField] float maxDistanceFromPlayer = 10f;


    // cache
    PlayPerspective playPerspective;
    PlayerInput playerInput;

    private void Start()
    {
        playPerspective = FindObjectOfType<PlayPerspective>();
        playerInput = FindObjectOfType<PlayerInput>();
    }

    void Update()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        Vector2 inputVector = playerInput.GetMovementVector();
        Perspective perspective = playPerspective.GetCurrentPerspective();

        if (inputVector == Vector2.zero
            || perspective != Perspective.XZ_TopDown)
        {
            if (transform.localPosition != Vector3.zero)
            {
                ReturnCameraToPlayer();
            }
            return;
        }

        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        float newDistanceFromParent = Vector3.Distance(newPosition, transform.parent.position);
        
        if (newDistanceFromParent < maxDistanceFromPlayer)
        {
            transform.position = newPosition;
        }

    }

    private void ReturnCameraToPlayer()
    {
        Vector3 moveDirection = transform.position - transform.parent.position;

        float baseMovementThisFrame = snapBackSpeed * Time.deltaTime;
        var distanceFromParent = Vector3.Distance(transform.position, transform.parent.position);

        if (distanceFromParent > baseMovementThisFrame)
        {
            transform.position -= moveDirection.normalized * baseMovementThisFrame * distanceFromParent;
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
