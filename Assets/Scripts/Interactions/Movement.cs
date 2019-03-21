using UnityEngine;

/// <summary>
/// Handles ship's impulse-like movement.
/// </summary>
[RequireComponent(typeof(Ship))]
public class Movement : MonoBehaviour
{
    /// <summary>
    /// Modifier of controlling the rate of change when the player desires a change in movement/rotation.
    /// </summary>
    [SerializeField]
    private int sensitivity = 100;

    /// <summary>
    /// Local reference of the ship's variable class.
    /// </summary>
    private Ship ship;

    /// <summary>
    /// Local reference to UI metre for ship's target speed.
    /// </summary>
    private GameObject speedFactorDisplay;

    void Start()
    {
        ship = GetComponent<Ship>();
        speedFactorDisplay = GameObject.FindGameObjectWithTag("Speedometre");
    }

    void Update()
    {
        ManageSpeed();
        ManageOrientation();

        MoveShip();
    }

    /// <summary>
    /// Polls for player-requested changes to the ship's
    /// target speed.
    /// </summary>
    private void ManageSpeed()
    {
        // Poll for direct speed changes
        if (Input.GetKey(KeyCode.Alpha0))
        {
            ship.SetSpeedFactor(SpeedFactor.Zero);
        }
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            speedFactorDisplay.transform.GetChild(0).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(1).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(2).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(3).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(4).gameObject.SetActive(false);
            ship.SetSpeedFactor(SpeedFactor.One);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            speedFactorDisplay.transform.GetChild(0).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(1).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(2).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(3).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(4).gameObject.SetActive(false);
            ship.SetSpeedFactor(SpeedFactor.Two);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            speedFactorDisplay.transform.GetChild(0).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(1).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(2).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(3).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(4).gameObject.SetActive(false);
            ship.SetSpeedFactor(SpeedFactor.Three);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            speedFactorDisplay.transform.GetChild(0).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(1).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(2).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(3).gameObject.SetActive(true);
            speedFactorDisplay.transform.GetChild(4).gameObject.SetActive(false);
            ship.SetSpeedFactor(SpeedFactor.Full);
        }
        else if (Input.GetKey(KeyCode.Minus))
        {
            speedFactorDisplay.transform.GetChild(0).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(1).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(2).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(3).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(4).gameObject.SetActive(true);
            ship.SetSpeedFactor(SpeedFactor.Reverse);
        }
        else if (ship.GetSpeedFactor() == SpeedFactor.Zero)
        {
            speedFactorDisplay.transform.GetChild(0).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(1).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(2).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(3).gameObject.SetActive(false);
            speedFactorDisplay.transform.GetChild(4).gameObject.SetActive(false);
        }

        // Poll for inertial dampening
        if (Input.GetKey(KeyCode.Space))
        {
            ship.DampenInertia();
        }
    }

    /// <summary>
    /// Polls for player-requested changes to the ship's
    /// orientation/rotation.
    /// </summary>
    private void ManageOrientation()
    {
        // Poll for frontal tilt changes
        if (Input.GetKey(KeyCode.W))
        {
            transform.GetChild(0).Rotate(Vector3.left * (sensitivity / 4) * Time.fixedDeltaTime);
            ship.DampenInertia();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.GetChild(0).Rotate(Vector3.right * (sensitivity / 4) * Time.fixedDeltaTime);
            ship.DampenInertia();
        }

        // Poll for side banking changes
        if (Input.GetKey(KeyCode.A))
        {
            transform.GetChild(0).Rotate(Vector3.down * (sensitivity / 4) * Time.fixedDeltaTime);
            ship.DampenInertia();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.GetChild(0).Rotate(Vector3.up * (sensitivity / 4) * Time.fixedDeltaTime);
            ship.DampenInertia();
        }

        // Poll for roll correction
        if (Input.GetKey(KeyCode.Q))
        {
            transform.GetChild(0).Rotate(Vector3.forward * (sensitivity / 4) * Time.fixedDeltaTime);
            ship.DampenInertia();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.GetChild(0).Rotate(Vector3.back * (sensitivity / 4) * Time.fixedDeltaTime);
            ship.DampenInertia();
        }
    }

    /// <summary>
    /// Just moves the ship.
    /// </summary>
    private void MoveShip()
    {
        transform.Translate(transform.GetChild(0).forward * ship.GetSpeed() * Time.deltaTime, Space.World);
    }
}