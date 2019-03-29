using UnityEngine;

/// <summary>
/// Detects and handles collisions between entities.
/// </summary>
public class Collisions : MonoBehaviour
{
    /// <summary>
    /// Internal reference to self.
    /// </summary>
    private Body body;

    private void Start()
    {
        body = GetComponent<Body>();

        // If no Body present, end script
        if (!body)
            Destroy(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Retrieve the Body of the object this collided with
        Body them = collision.transform.GetComponent<Planet>();

        // If no Body present on them, get out of here
        if (!them)
            return;

        Debug.Log("Collided with " + them.transform.name);

        // If collided with planet, immediately destroy
        // vessel
        body.DestroyBody();
    }
}
