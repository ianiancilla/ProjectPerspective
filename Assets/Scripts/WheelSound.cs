using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSound : MonoBehaviour
{
    [SerializeField] private Player player;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Pause();
    }

    private void OnEnable()
    {
        Player.onWalkingStatusChanged += OnWalkingStatusChanged;
    }

    private void OnDisable()
    {
        Player.onWalkingStatusChanged -= OnWalkingStatusChanged;
    }

    private void OnWalkingStatusChanged(bool isWalking)
    {
        //Debug.Log("called");
        if (isWalking)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }

}
