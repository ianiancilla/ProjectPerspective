using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    [SerializeField] MonoBehaviour componentToToggle;
    [SerializeField] GameObject gameObjectToToggle;

    public void ToggleComponent()
    {
        if (componentToToggle != null)
        {
            componentToToggle.enabled = !componentToToggle.enabled;
        }
        if (gameObjectToToggle != null)
        {
            gameObjectToToggle.SetActive(!gameObjectToToggle.activeSelf);
        }
    }

    public void EnableComponent()
    {
        if (componentToToggle != null)
        {
            componentToToggle.enabled = true;
        }
        if (gameObjectToToggle != null)
        {
            gameObjectToToggle.SetActive(true);
        }
    }

    public void DisableComponent()
    {
        if (componentToToggle != null)
        {
            componentToToggle.enabled = false;
        }
        if (gameObjectToToggle != null)
        {
            gameObjectToToggle.SetActive(false);
        }
    }
}
