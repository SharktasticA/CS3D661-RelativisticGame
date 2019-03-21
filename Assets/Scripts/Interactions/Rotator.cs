using UnityEngine;

/// <summary>
/// Allows object to be rotated at set speed.
/// </summary>
public class Rotator : MonoBehaviour
{
    /// <summary>
    /// Direction in which the object needs to be rotated.
    /// </summary>
    [SerializeField]
    private Rotation rotation = Rotation.Clockwise;

    /// <summary>
    /// Speed the object is rotated at.
    /// </summary>
    [SerializeField]
    private float rotationSpeed = 2.5f;

    private void Update()
    {
        if (rotation == Rotation.Clockwise)
            transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
        else if (rotation == Rotation.Anticlockwise)
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Sets new rotation speed for the rotator to use.
    /// </summary>
    /// <param name="newSpeed">New rotation speed.</param>
    public void SetSpeed(float newSpeed)
    {
        // Artificial clamp to prevent visual artefacts
        if (newSpeed > 1000f)
            newSpeed = 1000f;
        else if (newSpeed < -1000f)
            newSpeed = -1000f;
        else
            rotationSpeed = newSpeed;
    }
}