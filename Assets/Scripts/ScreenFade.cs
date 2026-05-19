using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    public Image blackImage; 
    public float fadeDuration = 2f; 

    public void StartFadeOut() // siyaha geçiş
    {
        StartCoroutine(FadeToBlack());
    }

    public void StartFadeIn() // siyah ekrandan açılma
    {
        StartCoroutine(FadeFromBlack());
    }

    IEnumerator FadeToBlack()
    {
        float elapsed = 0f;
        Color c = blackImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / fadeDuration);
            blackImage.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }
    }

    IEnumerator FadeFromBlack()
    {
        float elapsed = 0f;
        Color c = blackImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = 1f - Mathf.Clamp01(elapsed / fadeDuration);
            blackImage.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }
    
    }


    void Start()
    {
        Color a = blackImage.color;  
        blackImage.color = new Color(a.r,a.g,a.b,1);
        StartFadeIn();

    }

    
    void Update()
    {
        
    }
}
