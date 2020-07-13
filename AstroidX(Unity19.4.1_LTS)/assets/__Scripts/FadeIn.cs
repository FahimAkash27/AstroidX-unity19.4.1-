using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float duration = 0.4f;
    public CanvasGroup canvasGroup;

    public void Start()
    {
        Fade();
    }

    public void Fade()
    {

        StartCoroutine(DoFade(canvasGroup, 1, 0));
    }

    public IEnumerator DoFade(CanvasGroup canvGroup,float start, float end)
    {
        float counter = 0f;

        while(counter < duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;

        }
        
    }
}
