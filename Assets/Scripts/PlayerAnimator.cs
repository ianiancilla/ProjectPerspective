using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player player;

    private const string IS_WALKING = "IsWalking";

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Player.onWalkingStatusChanged += OnWalkingStatusChanged;
    }

    private void OnDisable()
    {
        Player.onWalkingStatusChanged -= OnWalkingStatusChanged;
    }

    private void OnWalkingStatusChanged(bool isWalking)
    {
        animator.SetBool(IS_WALKING, isWalking);
    }
}
