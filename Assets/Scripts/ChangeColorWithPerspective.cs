using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorWithPerspective : MonoBehaviour
{
    [ColorUsage(true, true)]
    [SerializeField] Color emissionOnX;

    [ColorUsage(true, true)]
    [SerializeField] Color emissionOnZ;

    [ColorUsage(true, true)]
    [SerializeField] Color emissionOnY;

    [SerializeField] Material[] materials;

    const string EMISSION_COLOR_PROPERTY = "_Emission_Color";

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
                AssignColor(emissionOnY);
                break;
            case Perspective.XY_Side:
                AssignColor(emissionOnZ);
                break;
            case Perspective.YZ_Side:
                AssignColor(emissionOnX);
                break;
            default:
                break;
        }
    }

    public void AssignColor(Color color)
    {
        foreach (var material in materials)
        {
            material.SetColor(EMISSION_COLOR_PROPERTY, color);
        }
    }

}
