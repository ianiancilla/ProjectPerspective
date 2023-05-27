using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVoice : MonoBehaviour
{
    [SerializeField] bool isActive;
    [SerializeField] float waitBetweenChirps;
    [SerializeField] float variationInWait;
    [SerializeField] AudioClip[] chirps;

    private bool isChirping = false;
    private float timer;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (!isActive) { return; }

        isChirping = audioSource.isPlaying;
        if (isChirping) { return; }

        // if it's between chrips
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            ResetTimer();
            Chirp();
        }
    }

    private void Chirp()
    {
        AudioClip nextChirp = chirps[Random.Range(0, chirps.Length)];
        audioSource.clip = nextChirp;

        audioSource.Play();

        isChirping=true;
    }

    private void ResetTimer()
    {
        float variation = Random.Range(-variationInWait, variationInWait);

        timer = waitBetweenChirps + variation;
    }
}
