/*
    Player probe movement
    Khalid Ali 2019
*/

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles impulse-based (inside star system) movement
/// </summary>
[RequireComponent(typeof(Ship))]
public class Movement : MonoBehaviour
{
    /// <summary>
    /// The speed that the ship is currently at
    /// </summary>
    private float currentSpeed;

    /// <summary>
    /// Calculated change in rotation due to movement changes
    /// </summary>
    private Vector3 angleVelocity;

    /// <summary>
    /// Local reference of the ship rotation's eular angles
    /// </summary>
    private Vector3 shipRotation;

    /// <summary>
    /// Modifier of controlling the rate of change when the player desires a change in movement/rotation
    /// </summary>
    [SerializeField]
    private int sensitivity = 100;

    /// <summary>
    /// Local reference of the ship's variable class
    /// </summary>
    private Ship ship;

    /// <summary>
    /// Reference to impulse factor display element
    /// </summary>
    private GameObject speedFactorDisplay;

    void Start()
    {
        ship = GetComponent<Ship>();
        speedFactorDisplay = GameObject.FindGameObjectWithTag("Speedometre");
    }

    /// <summary>
    /// Polls for requested changes in impulse factor and specifies desired speed for the rest of the script
    /// </summary>
    void ManageImpulse()
    {
        //check if change in warp factor is requested
        if (Input.GetKey(KeyCode.Alpha0))
        {
            ship.SetSpeedFactor(SpeedFactor.Off);
        }
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            speedFactorDisplay.transform.GetChild(0).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(1).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(2).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(3).gameObject.SetActive(false);
            ship.SetSpeedFactor(SpeedFactor.HalfQuarter);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            speedFactorDisplay.transform.GetChild(0).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(1).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(2).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(3).gameObject.SetActive(false);
            ship.SetSpeedFactor(SpeedFactor.Quarter);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            speedFactorDisplay.transform.GetChild(0).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(1).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(2).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(3).gameObject.SetActive(false);
            ship.SetSpeedFactor(SpeedFactor.Half);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            speedFactorDisplay.transform.GetChild(0).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(1).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(2).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(3).gameObject.SetActive(true);
            ship.SetSpeedFactor(SpeedFactor.Full);
        }
        else if (Input.GetKey(KeyCode.Minus))
        {
            speedFactorDisplay.transform.GetChild(0).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(1).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(2).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(3).gameObject.SetActive(false);
            ship.SetSpeedFactor(SpeedFactor.Reverse);
        }

        if (ship.GetSpeedFactor() == SpeedFactor.Off)
        {
            speedFactorDisplay.transform.GetChild(0).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(1).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(2).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Polls for requested changes in ship rotations
    /// </summary>
    void ManageRotation()
    {
        if (Input.GetKey(KeyCode.W)) transform.GetChild(0).Rotate(Vector3.left * (sensitivity / 4) * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.S)) transform.GetChild(0).Rotate(Vector3.right * (sensitivity / 4) * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.A)) transform.GetChild(0).Rotate(Vector3.down * (sensitivity / 4) * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.D)) transform.GetChild(0).Rotate(Vector3.up * (sensitivity / 4) * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Ensures ship is travelling at desired speed
    /// </summary>
    void ManageAcceleration()
    {
        if (ship.GetSpeedFactor() == SpeedFactor.Off) return;
        transform.Translate((transform.GetChild(0).forward * ship.GetImpulseSpeed()), Space.World);
    }

    void Update()
    {
        ManageImpulse();
        ManageRotation();
        ManageAcceleration();
    }
}