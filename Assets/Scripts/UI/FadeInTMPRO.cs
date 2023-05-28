using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeInTMPRO : MonoBehaviour
{
    [SerializeField] float fadeInTime = 1.5f;
    [SerializeField] float minAlpha = 0f;
    [SerializeField] float maxAlpha = 1f;

    // cache
    TextMeshProUGUI textMeshPro;

    float timer = 0f;

    private void OnEnable()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        timer = 0;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        if (fadeInTime == 0f) { yield break; }

        textMeshPro.alpha = minAlpha;

        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;
            float t = timer / fadeInTime;
            textMeshPro.alpha = Mathf.Lerp(minAlpha, maxAlpha, t);
            yield return new WaitForEndOfFrame();
        }
    }




}
