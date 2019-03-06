using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Enumeration of possible settings for a ship's impulse engines
/// </summary>
public enum SpeedFactor { Reverse, Off, HalfQuarter, Quarter, Half, Full };

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Rigidbody))]
class Ship : Body
{
    /// <summary>
    /// Maximum speed this ship can travel in star systems at (Full Impulse)
    /// </summary>
    [SerializeField]
    private float maxImpulseSpeed = 0.5f;

    /// <summary>
    /// Enumerated factor of impulse the ship's engines are set to
    /// </summary>
    private SpeedFactor speedFactor = SpeedFactor.Off;

    /// <summary>
    /// 
    /// </summary>
    private GameObject relativisticsMetre;

    /// <summary>
    /// 
    /// </summary>
    private float cooldown = 0.25f;

    private void Start()
    {
        relativisticsMetre = GameObject.FindGameObjectWithTag("Relativisticsmetre");
    }

    private void Update()
    {
        relativisticsMetre.transform.GetChild(0).GetComponent<Text>().text = "Speed: " + GetSpeedKMS() + "km/s";
        relativisticsMetre.transform.GetChild(1).GetComponent<Text>().text = "Gravity: " + GetGrav() + "g";
        relativisticsMetre.transform.GetChild(2).GetComponent<Text>().text = "Mass: " + GetMass() * 1000 + "kg";
        relativisticsMetre.transform.GetChild(3).GetComponent<Text>().text = "Length: " + GetLength() * 100 + "m";
    }

    /// <summary>
    /// Returns ship's speed factor
    /// </summary>
    /// <returns>Enumerated factor of speed the ship's engines are set to</returns>
    public SpeedFactor GetSpeedFactor() { return speedFactor; }

    /// <summary>
    /// Returns impulse engine's desired speed
    /// </summary>
    /// <returns>Float of the desired speed</returns>
    public float GetImpulseSpeed()
    {
        if (speedFactor == SpeedFactor.HalfQuarter) return maxImpulseSpeed / 8;
        else if (speedFactor == SpeedFactor.Quarter) return maxImpulseSpeed / 4;
        else if (speedFactor == SpeedFactor.Half) return maxImpulseSpeed / 2;
        else if (speedFactor == SpeedFactor.Full) return maxImpulseSpeed;
        else if (speedFactor == SpeedFactor.Off) return 0;
        else if (speedFactor == SpeedFactor.Reverse) return -maxImpulseSpeed / 16;
        else return 0;
    }

    /// <summary>
    /// Sets ship's impulse factor
    /// </summary>
    /// <param name="nSpeed">New speed factor for the engines to be set to</param>
    public void SetSpeedFactor(SpeedFactor nSpeed) { speedFactor = nSpeed; }
}