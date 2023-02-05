using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 5;
    [SerializeField] private float startDelay = 3;
    [SerializeField] private Image uiImage;

    private void Start()
    {
        StartCoroutine(FadeImage(0, fadeDuration));
    }

    private IEnumerator FadeImage(float targetOpacity, float duration)
    {
        yield return new WaitForSeconds(startDelay);
        float time = 0;
        float startOpacity = uiImage.color.a;
        while (time < duration)
        {
            uiImage.color = new Color(0, 0, 0, Mathf.Lerp(startOpacity, targetOpacity, time / duration));
            time += Time.deltaTime;
            yield return null;
        }
        uiImage.color = Color.clear;
        uiImage.gameObject.SetActive(false);
    }
}
