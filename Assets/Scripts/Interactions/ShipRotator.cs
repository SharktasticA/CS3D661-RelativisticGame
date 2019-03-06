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
}