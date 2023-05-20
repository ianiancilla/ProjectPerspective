using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;


public class NavMeshBaker : MonoBehaviour
{
    // cache
    NavMeshSurface navMeshSurface;

    private void Awake()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
    }

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
        switch (perspective)
        {
            case Perspective.XZ_TopDown:
                navMeshSurface.agentTypeID = 0; // Topdown agent
                break;
            case Perspective.XY_Side:
            case Perspective.YZ_Side:
                navMeshSurface.agentTypeID = 1; // Sideview agent
                break;
        }

        BakeMesh();
    }
    private void BakeMesh()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
