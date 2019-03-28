using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays frames-per-second for scene.
/// </summary>
public class FPSCounter : MonoBehaviour
{
    /// <summary>
    /// Internal reference to UI element for
    /// FPS counter.
    /// </summary>
    private Text fpsCounter;

    /// <summary>
    /// Stores last frame delta.
    /// </summary>
    float delta = 0.0f;

    private void Start()
    {
        fpsCounter = GameObject.FindGameObjectWithTag("FPSCounter").GetComponent<Text>();

        if (!fpsCounter)
            Destroy(this);
    }

    void Update()
    {
        delta += (Time.unscaledDeltaTime - delta) * 0.1f;
        fpsCounter.text = Mathf.RoundToInt(1.0f / delta) + "FPS";
    }
}
