using UnityEngine;

/// <summary>
/// 
/// </summary>
public class ShipRotator : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Rotation orbitRotation = Rotation.Clockwise;

    /// <summary>
    /// 
    /// </summary>
    private float rotationSpeed = 90f;

    private void Update()
    {
        if (orbitRotation == Rotation.Clockwise)
            transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
        else if (orbitRotation == Rotation.Anticlockwise)
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// /
    /// </summary>
    /// <param name="newSpeed"></param>
    public void SetSpeed(float newSpeed)
    {
        if (newSpeed > 1000f)
            newSpeed = 1000f;
        else if (newSpeed < -1000f)
            newSpeed = -1000f;
        else
            rotationSpeed = newSpeed;
    }
}