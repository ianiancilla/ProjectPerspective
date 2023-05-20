using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Cinemachine.CinemachineVirtualCamera XZ_TopDown;
    [SerializeField] Cinemachine.CinemachineVirtualCamera XY_Side;
    [SerializeField] Cinemachine.CinemachineVirtualCamera YZ_Side;

    Cinemachine.CinemachineVirtualCamera currentCamera;

    private void OnEnable()
    {
        PlayPerspective.onPerspectiveChanged += OnPerspectiveChanged;
    }

    private void OnDisable()
    {
        PlayPerspective.onPerspectiveChanged -= OnPerspectiveChanged;
    }

    private void OnPerspectiveChanged(Perspective perspective)
    {
        Cinemachine.CinemachineVirtualCamera newCamera;

        switch (perspective)
        {
            case Perspective.XZ_TopDown:
                newCamera = XZ_TopDown;
                break;
            case Perspective.XY_Side:
                newCamera = XY_Side;
                break;
            case Perspective.YZ_Side:
                newCamera= YZ_Side;
                break;
            default:
                newCamera = FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
                break;
        }

        newCamera.Priority = 20;

        if (currentCamera != null)
        {
            currentCamera.Priority = 10;
        }

        currentCamera = newCamera;
    }
}
