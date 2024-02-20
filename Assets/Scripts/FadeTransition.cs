using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeTransition : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 0.8f;

    private bool isFading = false;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void LoadSceneWithFade(string sceneName)
    {
        if (!isFading)
        {
            StartCoroutine(FadeOut(sceneName));
        }
    }

    IEnumerator FadeIn()
    {
        float alpha = fadeImage.color.a;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }

    IEnumerator FadeOut(string sceneName)
    {
        isFading = true;
        float alpha = fadeImage.color.a;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}
