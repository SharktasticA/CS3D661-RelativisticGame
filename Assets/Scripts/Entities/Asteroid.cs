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
    private float rotationSpeed = 1f;

    private void Start()
    {
        //Give the asteroid's properties some variance
        rb.mass *= Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(
            transform.localScale.x * Random.Range(0.125f, 1.875f),
            transform.localScale.y * Random.Range(0.125f, 1.875f),
            transform.localScale.z * Random.Range(0.125f, 1.875f));

        body = transform.GetChild(0);
        rotationSpeed = Random.Range(-rotationSpeed, rotationSpeed);
    }

    private void Update()
    {
        body.rotation = body.rotation * Quaternion.Euler(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime);
    }
}