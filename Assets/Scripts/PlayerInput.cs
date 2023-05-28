using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] bool isInputAccepted = true;

    private PlayerInputActions playerInputActions;

    // events
    public delegate void OnPerspectiveChangeInput(Perspective perspective);
    public static event OnPerspectiveChangeInput onPerspectiveChangeInput;

    public UnityEvent OnOpenMenu;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void OnEnable()
    {
        playerInputActions.Player.XY_Side_Activate.performed += OnXY_Side_Activate_performed;
        playerInputActions.Player.ZY_Side_Activate.performed += OnZY_Side_Activate_performed;
        playerInputActions.Player.XZ_TopDown_Activate.performed += OnXZ_TopDown_Activate_performed;
        playerInputActions.Player.OpenMenu.performed += OnOpenMenu_performed;
    }

    private void OnDisable()
    {
        playerInputActions.Player.XY_Side_Activate.performed -= OnXY_Side_Activate_performed;
        playerInputActions.Player.ZY_Side_Activate.performed -= OnZY_Side_Activate_performed;
        playerInputActions.Player.XZ_TopDown_Activate.performed -= OnXZ_TopDown_Activate_performed;
        playerInputActions.Player.OpenMenu.performed -= OnOpenMenu_performed;
    }

    private void OnXZ_TopDown_Activate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!isInputAccepted) { return; }
        onPerspectiveChangeInput?.Invoke(Perspective.XZ_TopDown);
    }

    private void OnZY_Side_Activate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!isInputAccepted) { return; }
        onPerspectiveChangeInput?.Invoke(Perspective.YZ_Side);
    }

    private void OnXY_Side_Activate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!isInputAccepted) { return; }
        onPerspectiveChangeInput?.Invoke(Perspective.XY_Side);
    }

    private void OnOpenMenu_performed(InputAction.CallbackContext obj)
    {
        if (!isInputAccepted) { return; }
        OnOpenMenu?.Invoke();
    }

    public Vector2 GetMovementVector()
    {
        if (!isInputAccepted) { return Vector2.zero; }
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }

    public void ToggleInputActivation()
    {
        isInputAccepted = !isInputAccepted;
    }

    public void ActivateInput()
    {
        isInputAccepted = true;
    }

    public void DeactivateInput()
    {
        isInputAccepted = false;
    }
}
