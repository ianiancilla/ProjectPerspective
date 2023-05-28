using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float waitTime = 1f;
    [SerializeField] GameObject objectToToggle;
    [SerializeField] AudioClip audioClip;
    [SerializeField] bool hasTriggerCollider;

    private void Start()
    {
        if (!hasTriggerCollider)
        {
            StartCoroutine(WaitAndTriggerTutorial());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!hasTriggerCollider) { return; }
        StartCoroutine(WaitAndTriggerTutorial());
    }

    IEnumerator WaitAndTriggerTutorial()
    {
        yield return new WaitForSeconds(waitTime);

        objectToToggle.SetActive(true);
    }
}
