using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/// <summary>
/// Enumarated possible quality levels the game uses.
/// </summary>
public enum QualityLevel { High = 0, Medium = 1, Low = 2 }

/// <summary>
/// Allows additional tasks to be performed at game
/// start based on quality level.
/// </summary>
public class QualityControl : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private QualityLevel quality;

    private void Start()
    {
        quality = (QualityLevel)QualitySettings.GetQualityLevel();

        // If quality is low, turn off PPS and lens flare
        if (quality == QualityLevel.Low)
        {
            GetComponent<PostProcessLayer>().enabled = false;
            GetComponent<FlareLayer>().enabled = false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public QualityLevel GetQualityLevel() { return quality; }
}