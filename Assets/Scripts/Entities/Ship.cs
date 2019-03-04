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
    /// 
    /// </summary>
    protected float grav = 0;

    /// <summary>
    /// Maximum speed this ship can travel in star systems at (Full Impulse)
    /// </summary>
    [SerializeField]
    private float maxImpulseSpeed = 0.5f;

    /// <summary>
    /// Enumerated factor of impulse the ship's engines are set to
    /// </summary>
    private SpeedFactor speed = SpeedFactor.Off;

    /// <summary>
    /// 
    /// </summary>
    private GameObject relativisticsMetre;

    private void Start()
    {
        relativisticsMetre = GameObject.FindGameObjectWithTag("Relativisticsmetre");
    }

    private void LateUpdate()
    {
        relativisticsMetre.transform.GetChild(0).GetComponent<Text>().text = "Gravity: " + grav * 100 + "g";
        relativisticsMetre.transform.GetChild(1).GetComponent<Text>().text = "Mass: " + GetMass() * 1000 + "kg";
        relativisticsMetre.transform.GetChild(2).GetComponent<Text>().text = "Length: 0m";
    }

    /// <summary>
    /// Returns ship's speed factor
    /// </summary>
    /// <returns>Enumerated factor of speed the ship's engines are set to</returns>
    public SpeedFactor GetSpeedFactor() { return speed; }

    /// <summary>
    /// Returns impulse engine's desired speed
    /// </summary>
    /// <returns>Float of the desired speed</returns>
    public float GetImpulseSpeed()
    {
        if (speed == SpeedFactor.HalfQuarter) return maxImpulseSpeed / 8;
        else if (speed == SpeedFactor.Quarter) return maxImpulseSpeed / 4;
        else if (speed == SpeedFactor.Half) return maxImpulseSpeed / 2;
        else if (speed == SpeedFactor.Full) return maxImpulseSpeed;
        else if (speed == SpeedFactor.Off) return 0;
        else if (speed == SpeedFactor.Reverse) return -maxImpulseSpeed / 16;
        else return 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetGrav() { return grav; }

    /// <summary>
    /// Sets ship's impulse factor
    /// </summary>
    /// <param name="nSpeed">New speed factor for the engines to be set to</param>
    public void SetSpeedFactor(SpeedFactor nSpeed) { speed = nSpeed; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="newGrav"></param>
    public void SetGrav(float newGrav) { grav = newGrav; }
}