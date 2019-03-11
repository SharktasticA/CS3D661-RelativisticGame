using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Enumeration of possible speed factors the ship's impulse engines can support.
/// </summary>
public enum SpeedFactor { Reverse = -16, Zero = 0, One = 256, Two = 32, Three = 4, Full = 1 };

/// <summary>
/// Body-subclass for scene ship objects.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
class Ship : Body
{
    /// <summary>
    /// The maximum speed this ship can travel at when SpeedFactor is Full
    /// </summary>
    [SerializeField]
    private float maxSpeed = 250f;

    /// <summary>
    /// Impulse factor this ship is set to use.
    /// </summary>
    private SpeedFactor speedFactor = SpeedFactor.Zero;

    /// <summary>
    /// Internal reference to relativistics UI display.
    /// </summary>
    private GameObject relativisticsMetre;

    /// <summary>
    /// Internal reference to all parts of the ship that can rotate.
    /// </summary>
    private ShipRotator[] rotatables;

    private void Start()
    {
        //Get relativistics UI reference
        relativisticsMetre = GameObject.FindGameObjectWithTag("Relativisticsmetre");
        //Find all rotatable ship parts
        rotatables = FindObjectsOfType<ShipRotator>();
    }

    private void Update()
    {
        //Gradually accelerate/decelerate the ship to the desired speed
        speed = Mathf.Lerp(speed, GetSpeedTarget(), 0.01f);

        //Ensure all rotatable ship parts turn at the proper speed
        for (int i = 0; i < rotatables.Length; i++)
            rotatables[i].SetSpeed(speed * 10f);

        //Update all relativistic UI display readouts
        relativisticsMetre.transform.GetChild(0).GetComponent<Text>().text = "Speed: " + GetSpeedKMS() + "km/s";
        relativisticsMetre.transform.GetChild(1).GetComponent<Text>().text = "Gravity: " + GetGrav() + "g";
        relativisticsMetre.transform.GetChild(2).GetComponent<Text>().text = "Mass: " + GetMass() * 1000 + "kg";
        relativisticsMetre.transform.GetChild(3).GetComponent<Text>().text = "Length: " + GetLength() * 100 + "m";
    }

    /// <summary>
    /// Returns ship's impulse factor setting.
    /// </summary>
    public SpeedFactor GetSpeedFactor() { return speedFactor; }

    /// <summary>
    /// Returns ship's target speed.
    /// </summary>
    public float GetSpeedTarget()
    {
        if (speedFactor == SpeedFactor.Zero) return 0;
        else return maxSpeed / (int)speedFactor;
    }

    /// <summary>
    /// Accepts and sets the ship's impulse factor setting.
    /// </summary>
    /// <param name="nSpeed">New SpeedFactor setting for the ship's impulse engines.</param>
    public void SetSpeedFactor(SpeedFactor nSpeed) { speedFactor = nSpeed; }
}