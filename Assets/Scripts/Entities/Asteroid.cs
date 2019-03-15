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
    private float rotationSpeed;

    private void Start()
    {
        //Give the asteroid's properties some variance
        rb.mass *= Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(
            transform.localScale.x * Random.Range(0.5f, 1.5f),
            transform.localScale.y * Random.Range(0.5f, 1.5f),
            transform.localScale.z * Random.Range(0.5f, 1.5f));

        body = transform.GetChild(0);
        rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
    }

    private void Update()
    {
        body.rotation = body.rotation * Quaternion.Euler(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime);
    }
}