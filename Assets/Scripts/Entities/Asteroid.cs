using UnityEngine;

/// <summary>
/// Body-subclass for scene asteroid objects.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Asteroid : Body
{
    /// <summary>
    /// Internal reference to the physical asteroid model.
    /// </summary>
    private Transform body;

    /// <summary>
    /// Speed in which the physical model is rotated.
    /// </summary>
    [SerializeField]
    private float rotationSpeed = 16f;

    private void Start()
    {
        // Give the asteroid's properties some variance
        rb.mass *= Random.Range(0.5f, 1.5f);
        rotationSpeed = Random.Range(-rotationSpeed, rotationSpeed);
        body = transform.GetChild(0);
    }

    private void Update()
    {
        body.rotation = body.rotation * Quaternion.Euler(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime);
    }
}