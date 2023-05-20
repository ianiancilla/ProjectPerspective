using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        float playerHeight = 1f;
        float playerRadius = .35f;
        
        bool CanMove(Vector3 direction)
        {
            bool canMove = !Physics.CapsuleCast(transform.position + (Vector3.up * (playerRadius / 2f)),
                                                transform.position + Vector3.up * (playerHeight - playerRadius),
                                                playerRadius,
                                                direction,
                                                moveSpeed * Time.deltaTime);
            return canMove;
        }

        if (!CanMove(moveDirection))
        {
            // try only x movement
            Vector3 moveX = new Vector3(moveDirection.x, 0,0).normalized;

            if (CanMove(moveX))
            {
                moveDirection = moveX;
            }
            else
            {
                // try only z movement
                Vector3 moveZ = new Vector3(0,0,moveDirection.z).normalized;

                if (CanMove(moveZ))
                {
                    moveDirection = moveZ;
                }
                else
                {
                    // cannot move at all
                    Debug.Log("Player cannot move in this direction");
                    return;
                }
            }
        }

        isWalking = true;
        transform.position += moveDirection * Time.deltaTime * moveSpeed;
    }
}
