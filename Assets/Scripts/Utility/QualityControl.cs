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
    private Camera mCamera;

    /// <summary>
    /// 
    /// </summary>
    private QualityLevel quality;

    /// <summary>
    /// 
    /// </summary>
    bool vSyncToggle = true;

    private void Start()
    {
        mCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        if (!mCamera)
            Destroy(this);

        quality = (QualityLevel)QualitySettings.GetQualityLevel();

        // If quality is low, turn off PPS and lens flare
        if (quality == QualityLevel.Low)
        {
            mCamera.GetComponent<PostProcessLayer>().enabled = false;
            mCamera.GetComponent<FlareLayer>().enabled = false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="newLevel"></param>
    public void SetQualityLevel(int newLevel)
    {
        // If quality is low, turn off PPS and lens flare
        if ((QualityLevel)newLevel == QualityLevel.Low)
        {
            mCamera.GetComponent<PostProcessLayer>().enabled = false;
            mCamera.GetComponent<FlareLayer>().enabled = false;
        }
        else
        {
            mCamera.GetComponent<PostProcessLayer>().enabled = true;
            mCamera.GetComponent<FlareLayer>().enabled = true;
        }

        QualitySettings.SetQualityLevel(newLevel);
        quality = (QualityLevel)newLevel;

        if (vSyncToggle)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;
    }

    /// <summary>
    /// 
    /// </summary>
    public QualityLevel GetQualityLevel() { return quality; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="toggle"></param>
    public void ToggleVSync()
    {
        vSyncToggle = !vSyncToggle;

        if (vSyncToggle)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;
    }
}