using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Collisions : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private Body body;

    private void Start()
    {
        body = GetComponent<Body>();

        //
        if (!body)
            Destroy(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Retrieve the Body of the object this collided with
        Body them = collision.transform.parent.GetComponent<Body>();

        //
        if (!them)
            return;

        Debug.Log("Collided with " + them.transform.name);
    }
}
