using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMixer : MonoBehaviour
{
    private const string VOLUME_PREF = "Volume";

    void Start()
    {
        ApplyVolume();
    }

    public void SetVolumePref(float newVolume)
    {
        PlayerPrefs.SetFloat(VOLUME_PREF, newVolume);
        ApplyVolume();
    }

    public float GetVolumePref()
    {
        return PlayerPrefs.GetFloat(VOLUME_PREF, 1);
    }

    public void ApplyVolume()
    {
        AudioListener.volume = PlayerPrefs.GetFloat(VOLUME_PREF, 1f);
    }
}
