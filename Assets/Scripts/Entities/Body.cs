using UnityEngine;

/// <summary>
/// Basic physics-enabled scene object class. This class is inherited
/// by Planet, Ship.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Body : MonoBehaviour
{
    /// <summary>
    /// Internal reference to this object's Rigidbody.
    /// </summary>
    protected Rigidbody rb;

    /// <summary>
    /// Cached overall speed of the object, factoring in impulse and
    /// gravitational pull.
    /// </summary>
    protected float speed = 0;

    /// <summary>
    /// Cached gravitational force applied on this object from neighbours.
    /// </summary>
    private float grav = 0;

    /// <summary>
    /// Cached last position used for calculating the speed of the object
    /// from how its being pushed by gravity.
    /// </summary>
    private Vector3 lastPos;

    /// <summary>
    /// 
    /// </summary>
    private float initSpeedCooldown = 1f;

    private void Awake()
    {
        //Get reference to RB
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (initSpeedCooldown <= 0)
        {
            //Work out speed due to gravity pull so that non-ship objects can have
            //some sort of speed reading.
            speed += (transform.position - lastPos).magnitude * Time.fixedDeltaTime;
            lastPos = transform.position;
        }
        else initSpeedCooldown -= 1f * Time.fixedDeltaTime;
    }

    /// <summary>
    /// Returns the object's current mass.
    /// </summary>
    public float GetMass() { return rb.mass; }

    /// <summary>
    /// Returns the object's current length (or diametre).
    /// </summary>
    public float GetLength() { return (transform.GetChild(0).GetComponent<MeshFilter>().mesh.bounds.extents.z * transform.GetChild(0).localScale.z); }

    /// <summary>
    /// Returns the object's overall speed.
    /// </summary>
    public float GetSpeed() { return speed; }

    /// <summary>
    /// Returns the object's speed in kilometres per second.
    /// </summary>
    public float GetSpeedKMS() { return speed * 100; }

    /// <summary>
    /// Returns the object's speed in kilometres per hour.
    /// </summary>
    public float GetSpeedKPH() { return GetSpeedKMS() * 3600; }

    /// <summary>
    /// Returns overall gravitational force being applied to the object.
    /// </summary>
    public float GetGrav() { return grav * 100; }

    /// <summary>
    /// Accepts and applies given force against this object.
    /// </summary>
    /// <param name="incomingForce">The force you want to apply against the object.</param>
    public void ApplyForce(Vector3 incomingForce) { rb.AddForce(incomingForce, ForceMode.Force); }

    /// <summary>
    /// Accepts and applies given torque against this object.
    /// </summary>
    /// <param name="incomingTorque">The torque you want to apply against the object.</param>
    public void ApplyTorque(Vector3 incomingTorque) { rb.AddTorque(incomingTorque, ForceMode.Force); }

    /// <summary>
    /// Accepts and sets new mass value to this object's rigidbody.
    /// </summary>
    /// <param name="newMass">The new mass.</param>
    public void SetMass(float newMass) { rb.mass = newMass; }

    /// <summary>
    /// Accepts and sets new length on usual direction of travel.
    /// </summary>
    /// <param name="newLength">The new length.</param>
    public void SetLength(float newLength)
    {
        //Compile a new scale vector
        Vector3 newScale = new Vector3(
            transform.GetChild(0).localScale.x,
            transform.GetChild(0).localScale.y,
            newLength / transform.GetChild(0).GetComponent<MeshFilter>().mesh.bounds.extents.z);

        transform.GetChild(0).localScale = newScale;
    }

    /// <summary>
    /// Accepts and stores the gravititional force being applied against this object.
    /// </summary>
    /// <param name="newGrav">The new grav.</param>
    public void StoreGrav(float newGrav) { grav = newGrav; }

    /// <summary>
    /// Resets any velocity applied to object via impacts, AddForce, or AddTorque.
    /// </summary>
    public void DampenInertia() { rb.velocity = rb.angularVelocity = Vector3.zero; }
}