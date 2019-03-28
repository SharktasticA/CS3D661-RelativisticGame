using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Provides centralised physics constants.
/// </summary>
public class Constants : MonoBehaviour
{
    /// <summary>
    /// Base gravitational constant value.
    /// </summary>
    [SerializeField]
    private float gravitationalConstant = 0.6674f;

    /// <summary>
    /// Base light speed in vacuum constant value.
    /// </summary>
    [SerializeField]
    private float lightSpeedConstant = 29979.2458f;

    /// <summary>
    /// Internal reference to the modifer slider for
    /// gravitational constant.
    /// </summary>
    private Slider gSlider;

    /// <summary>
    /// Internal reference to the modifer slider for
    /// light speed in vacuum constant.
    /// </summary>
    private Slider cSlider;

    private void Start()
    {
        gSlider = GameObject.FindGameObjectWithTag("GSlider").GetComponent<Slider>();
        cSlider = GameObject.FindGameObjectWithTag("CSlider").GetComponent<Slider>();

        if (!gSlider || !cSlider)
            Destroy(this);
    }

    /// <summary>
    /// Speed of light in a vacuum constant. Measured in km/s.
    /// </summary>
    public float G()
    {
        return gravitationalConstant * 2f + (gravitationalConstant * (gSlider.value / 100));
    }

    /// <summary>
    /// Speed of light in a vacuum constant. Measured in km/s.
    /// </summary>
    public float C()
    {
        return lightSpeedConstant + (lightSpeedConstant * (cSlider.value / 100));
    }
}