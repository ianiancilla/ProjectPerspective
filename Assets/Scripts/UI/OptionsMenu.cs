using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsActiveFirstButton;
    [SerializeField] GameObject optionsClosedFirstButton;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsActiveFirstButton);
    }

    private void OnDisable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsClosedFirstButton);
    }
}
