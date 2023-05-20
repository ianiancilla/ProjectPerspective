using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;


public class NavMeshBaker : MonoBehaviour
{
    // constants
    private const string AGENT_NAME_TOPDOWN = "TopDown";
    private const string AGENT_NAME_SIDEVIEW = "SideView";

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
                navMeshSurface.agentTypeID = GetAgentTypeIDByName(AGENT_NAME_TOPDOWN);
                break;
            case Perspective.XY_Side:
            case Perspective.YZ_Side:
                navMeshSurface.agentTypeID = GetAgentTypeIDByName(AGENT_NAME_SIDEVIEW);
                break;
        }

        BakeMesh();
    }
    private void BakeMesh()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }

    // shamelessly lifted from the web as I could not find good info on Unity docs
    // https://answers.unity.com/questions/1650130/change-agenttype-at-runtime.html
    private int GetAgentTypeIDByName(string agentTypeName)
    {
        int count = NavMesh.GetSettingsCount();
        string[] agentTypeNames = new string[count + 2];
        for (var i = 0; i < count; i++)
        {
            int id = NavMesh.GetSettingsByIndex(i).agentTypeID;
            string name = NavMesh.GetSettingsNameFromID(id);
            if (name == agentTypeName)
            {
                return id;
            }
        }
        return -1;
    }
}
