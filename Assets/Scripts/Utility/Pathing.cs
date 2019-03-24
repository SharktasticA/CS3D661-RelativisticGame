using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Pathing : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Vector3[] positions;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private SpeedFactor[] speeds;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float targetDist = 1f;

    /// <summary>
    /// 
    /// </summary>
    private int current = 0;

    /// <summary>
    /// 
    /// </summary>
    private Vector3 target = Vector3.zero;

    /// <summary>
    /// Local reference of the ship's variable class
    /// </summary>
    private Ship ship;

    private void Start()
    {
        //
        if (positions.Length == 0 || speeds.Length == 0)
        {
            //Debug.Log("Pathing: data defficient");
            Destroy(this);
        }

        //
        if (positions.Length != speeds.Length)
        {
            //Debug.Log("Pathing: each position must have a corresponding speed (and vice versa)");
            Destroy(this);
        }
        
        ship = GetComponent<Ship>();
        Time.timeScale -= 0.1f;
    }

    private void FixedUpdate()
    {
        //
        if (current == positions.Length)
        {
            //Debug.Log("Pathing: all positions visited");
            ship.SetSpeedFactor(SpeedFactor.Zero);
            Destroy(this);
            return;
        }

        //
        if (target == Vector3.zero)
        {
            target = transform.position + positions[current];
            //Debug.Log("Pathing: targetting " + target + " compared to current " + transform.position);
            return;
        }

        //
        if (Vector3.Distance(transform.position, target) < targetDist)
        {
            target = Vector3.zero;
            current++;
            return;
        }

        //
        if (ship.GetSpeedFactor() != speeds[current])
            ship.SetSpeedFactor(speeds[current]);

        //
        Vector3 direction = Vector3.RotateTowards(transform.GetChild(0).forward, target - transform.position, 0.125f * Time.fixedDeltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(direction);

        //
        transform.Translate(transform.GetChild(0).forward * ship.GetSpeed() * Time.fixedDeltaTime, Space.World);
    }
}
