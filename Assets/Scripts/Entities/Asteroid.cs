using UnityEngine;

/// <summary>
/// Body-subclass for scene asteroid objects.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Asteroid : Body
{
    /// <summary>
    /// 
    /// </summary>
    private Transform body;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float maxRotationSpeed = 1f;

    /// <summary>
    /// 
    /// </summary>
    private float rotationSpeedX;
    /// <summary>
    /// 
    /// </summary>
    private float rotationSpeedY;
    /// <summary>
    /// 
    /// </summary>
    private float rotationSpeedZ;

    /// <summary>
    /// 
    /// </summary>
    private float rotationSpeed;

    private void Start()
    {
        body = transform.GetChild(0);
        rotationSpeedX = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        rotationSpeedY = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        rotationSpeedZ = Random.Range(-maxRotationSpeed, maxRotationSpeed);
    }

    private void Update()
    {
        body.rotation = body.rotation * Quaternion.Euler(rotationSpeedX * Time.deltaTime, rotationSpeedY * Time.deltaTime, rotationSpeedZ * Time.deltaTime);
    }
}