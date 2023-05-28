using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClicker : MonoBehaviour
{
    public void Click()
    {
        GetComponent<Button>().onClick?.Invoke();
    }
}
