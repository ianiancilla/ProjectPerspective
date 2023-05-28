using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float waitTime = 1f;
    [SerializeField] GameObject objectToToggle;
    [SerializeField] AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(WaitAndTriggerTutorial());
    }

    IEnumerator WaitAndTriggerTutorial()
    {
        yield return new WaitForSeconds(waitTime);

        objectToToggle.SetActive(true);
    }
}
