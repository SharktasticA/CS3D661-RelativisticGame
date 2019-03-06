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
    private Vector3 lastPos;

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

    /// <summary>
    /// 
    /// </summary>
    private float cooldown = 0.25f;

    private void Update()
    {
        if (orbitRotation == Rotation.Clockwise)
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        else if (orbitRotation == Rotation.Anticlockwise)
            transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        cooldown -= 1f * Time.fixedDeltaTime;
        if (cooldown <= 0f)
        {
            speed = (transform.position - lastPos).magnitude * Time.fixedDeltaTime;
            lastPos = transform.position;
            cooldown = 0.25f;
        }
    }
}