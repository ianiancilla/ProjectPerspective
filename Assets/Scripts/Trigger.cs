using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    public UnityEvent triggeredByPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == PLAYER_TAG)
        {
            triggeredByPlayer?.Invoke();
        }
    }
}
