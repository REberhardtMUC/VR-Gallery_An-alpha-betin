using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class VideoFadeOut : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public CanvasGroup canvasGroup;
    public float fadeDuration = 2f;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float t = 0f;
        float startAlpha = canvasGroup.alpha;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, t / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
    }
}
