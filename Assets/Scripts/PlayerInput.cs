using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    // events
    public delegate void OnPerspectiveChangeInput(Perspective perspective);
    public static event OnPerspectiveChangeInput onPerspectiveChangeInput;


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
    }

    private void OnDisable()
    {
        playerInputActions.Player.XY_Side_Activate.performed -= OnXY_Side_Activate_performed;
        playerInputActions.Player.ZY_Side_Activate.performed -= OnZY_Side_Activate_performed;
        playerInputActions.Player.XZ_TopDown_Activate.performed -= OnXZ_TopDown_Activate_performed;
    }

    private void OnXZ_TopDown_Activate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        onPerspectiveChangeInput?.Invoke(Perspective.XZ_TopDown);
    }

    private void OnZY_Side_Activate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        onPerspectiveChangeInput?.Invoke(Perspective.YZ_Side);
    }

    private void OnXY_Side_Activate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        onPerspectiveChangeInput?.Invoke(Perspective.XY_Side);
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }

}
