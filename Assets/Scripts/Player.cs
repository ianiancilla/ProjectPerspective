using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] float moveSpeed = 7f;

    // variables
    private bool isWalking = false;

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = playerInput.GetMovementVector();

        if (inputVector == Vector2.zero)
        {
            isWalking = false;
            return;
        }

        // move
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        Vector3 goalPosition = transform.position + (moveDirection * moveSpeed * Time.deltaTime);
        Vector3 facingDirection = moveDirection;

        float maxDistance = .3f;
        bool isValidTarget = NavMesh.SamplePosition(goalPosition, out NavMeshHit navMeshHit, maxDistance, NavMesh.AllAreas);

        if (isValidTarget)
        {
            facingDirection = (navMeshHit.position - transform.position).normalized;

            transform.position = navMeshHit.position;
        }

        transform.forward = Vector3.Slerp(transform.forward, facingDirection, Time.deltaTime * moveSpeed);

    }
}
