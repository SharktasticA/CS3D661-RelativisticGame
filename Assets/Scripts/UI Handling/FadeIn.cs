using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class FadeIn : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Image toDisplay;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float timeUntilDisplay = 2.5f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float fadeInSpeed = 0.5f;

    /// <summary>
    /// Fades images into view via alpha.
    /// </summary>
    private IEnumerator fadeIn()
    {
        for (float i = 0; i <= 1; i += fadeInSpeed * Time.deltaTime)
        {
            toDisplay.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

    private void Start()
    {
        toDisplay.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (timeUntilDisplay <= 0)
        {
            toDisplay.gameObject.SetActive(true);
            StartCoroutine(fadeIn());
        }
        else
        {
            timeUntilDisplay -= 1f * Time.deltaTime;
            return;
        }
    }
}