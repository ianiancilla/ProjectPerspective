using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavMeshSurfaceUpdater : MonoBehaviour
{
    public Unity.AI.Navigation.NavMeshSurface[] surfaces;

    private void OnEnable()
    {
        PlayPerspective.onPerspectiveChanged += OnPerspectiveChanged;
    }

    private void OnDisable()
    {
        PlayPerspective.onPerspectiveChanged -= OnPerspectiveChanged;
    }

    void Start()
    {
        BakeMeshes();
    }

    private void OnPerspectiveChanged(Perspective perspective)
    {
        BakeMeshes();
    }
    private void BakeMeshes()
    {
        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }
}
