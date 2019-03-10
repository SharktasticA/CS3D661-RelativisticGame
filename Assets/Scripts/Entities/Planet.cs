using UnityEngine;

/// <summary>
/// Enumaration of possible directions this object can rotate to.
/// </summary>
public enum Rotation { Clockwise = 0, Anticlockwise = 1 };

/// <summary>
/// Body-subclass for scene planet objects.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
class Planet : Body
{
    /// <summary>
    /// The direction you want this planet to rotate in.
    /// </summary>
    [SerializeField]
    private Rotation orbitRotation = Rotation.Clockwise;

    /// <summary>
    /// The speed you want this planet to rotate by.
    /// </summary>
    [SerializeField]
    private float rotationSpeed = 0.5f;

    private void Update()
    {
        if (orbitRotation == Rotation.Clockwise)
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        else if (orbitRotation == Rotation.Anticlockwise)
            transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
    }
}