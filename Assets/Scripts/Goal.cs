using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Goal : MonoBehaviour
{
    [SerializeField] PlayableDirector levelClearTimeline;

    // constants
    private const string PLAYER_TAG = "Player";
    private void OnTriggerEnter(Collider other)
    
    {
        if (other.gameObject.tag == PLAYER_TAG)
        {
            levelClearTimeline.Play();
        }
    }
}
