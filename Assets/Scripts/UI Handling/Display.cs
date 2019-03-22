using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class Display : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private GameObject toDisplay;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float timeUntilDisplay = 2.5f;

    private void Start()
    {
        toDisplay.GetComponent<Image>().canvasRenderer.SetAlpha(0);
        toDisplay.SetActive(false);
    }

    private void Update()
    {
        if (timeUntilDisplay <= 0)
        {
            toDisplay.SetActive(true);
            toDisplay.GetComponent<Image>().CrossFadeAlpha(1f, 5f, false);
            Destroy(this);
        }
        else
        {
            timeUntilDisplay -= 1f * Time.deltaTime;
            return;
        }
    }
}