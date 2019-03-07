using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public enum Rotation { Clockwise = 0, Anticlockwise = 1 };

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Rigidbody))]
class Planet : Body
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Rotation orbitRotation = Rotation.Clockwise;

    /// <summary>
    /// 
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