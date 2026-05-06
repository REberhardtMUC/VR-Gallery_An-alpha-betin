using UnityEngine;
using UnityEngine.Video;
using System.Collections;

[RequireComponent(typeof(VideoPlayer))]
public class VideoFadeOut : MonoBehaviour
{
    public Renderer targetRenderer;   // Das Objekt mit dem Material
    public float fadeDuration = 2f;   // Dauer des Fade-Outs in Sekunden

    private VideoPlayer videoPlayer;
    private Material materialInstance;
    private bool isFading = false;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        if (targetRenderer == null)
        {
            Debug.LogError("Kein Renderer zugewiesen!");
            return;
        }

        // Wichtig: Instanz des Materials erzeugen (sonst änderst du das Original)
        materialInstance = targetRenderer.material;

        // Optional: Sicherstellen, dass der Shader Transparenz kann
        SetupMaterialForTransparency();

        // Event registrieren (falls du exakt am Ende faden willst)
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void Update()
    {
        // Startet den Fade kurz vor Ende (optional, aber meist schöner)
        if (!isFading && videoPlayer.isPlaying)
        {
            double timeLeft = videoPlayer.length - videoPlayer.time;

            if (timeLeft <= fadeDuration)
            {
                StartCoroutine(FadeOut());
                isFading = true;
            }
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Falls Fade noch nicht gestartet wurde
        if (!isFading)
        {
            StartCoroutine(FadeOut());
            isFading = true;
        }
    }

    IEnumerator FadeOut()
    {
        float t = 0f;
        Color color = materialInstance.color;

        float startAlpha = color.a;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, 0f, t / fadeDuration);

            color.a = alpha;
            materialInstance.color = color;

            yield return null;
        }

        // Sicherstellen, dass es komplett unsichtbar ist
        color.a = 0f;
        materialInstance.color = color;
    }

    void SetupMaterialForTransparency()
    {
        // Standard Shader auf Transparent setzen
        materialInstance.SetFloat("_Mode", 3); // Transparent

        materialInstance.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        materialInstance.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        materialInstance.SetInt("_ZWrite", 0);

        materialInstance.DisableKeyword("_ALPHATEST_ON");
        materialInstance.EnableKeyword("_ALPHABLEND_ON");
        materialInstance.DisableKeyword("_ALPHAPREMULTIPLY_ON");

        materialInstance.renderQueue = 3000;
    }
}