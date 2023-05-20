using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Perspective
{
    XZ_TopDown,
    XY_Side,
    YZ_Side
}

public class PlayPerspective : MonoBehaviour
{
    // variables
    private Perspective currentPerspective;

    // events
    public delegate void OnPerspectiveChanged(Perspective perspective);
    public static event OnPerspectiveChanged onPerspectiveChanged;

    private void OnEnable()
    {
        PlayerInput.onPerspectiveChangeInput += ChangePerspective;
    }
    private void OnDisable()
    {
        PlayerInput.onPerspectiveChangeInput -= ChangePerspective;
    }


    private void ChangePerspective (Perspective newPerspective)
    {
        currentPerspective = newPerspective;
        onPerspectiveChanged?.Invoke(currentPerspective);
    }

    public Perspective GetCurrentPerspective() => currentPerspective;
}
