using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    [SerializeField] MonoBehaviour componentToToggle;

    public void ToggleComponent()
    {
        componentToToggle.enabled = !componentToToggle.enabled;
    }

    public void EnableComponent()
    {
        if (componentToToggle != null)
        {
            componentToToggle.enabled = true;
        }
    }

    public void DisableComponent()
    {
        if (componentToToggle != null)
        {
            componentToToggle.enabled = false;
        }
    }
}
