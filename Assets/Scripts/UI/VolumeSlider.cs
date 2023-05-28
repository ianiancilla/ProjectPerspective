using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    //cache
    VolumeMixer volumeMixer;
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        volumeMixer = FindObjectOfType<VolumeMixer>();

        slider.value = volumeMixer.GetVolumePref();
    }

    public void ApplySliderValue()
    {
        volumeMixer.SetVolumePref(slider.value);
    }
}
