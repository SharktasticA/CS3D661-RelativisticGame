using System.Collections.Generic;
using UnityEngine;
using Assets;

/// <summary>
/// Newtonian gravity physics simulation.
/// </summary>
[RequireComponent(typeof(Body))]
public class Gravimetrics : MonoBehaviour
{
    /// <summary>
    /// Internal reference to body to apply effects to.
    /// </summary>
    private Body body;

    /// <summary>
    /// Internal reference to all scene bodies.
    /// </summary>
    List<Body> others = new List<Body>();

    /// <summary>
    /// Cached total gravitational force calculated in a given physics update.
    /// </summary>
    float totalGrav = 0;

    private void Start()
    {
        body = GetComponent<Body>();

        // Get all GameObjects in the scene that are flagged as "Body"
        GameObject[] otherObjs = GameObject.FindGameObjectsWithTag("Body");

        // Filter out GameObjects that don't actually have Body (or subclass)
        // attached to them
        for (int i = 0; i < otherObjs.Length; i++)
            if (otherObjs[i].GetComponent<Body>())
                others.Add(otherObjs[i].GetComponent<Body>());
    }

    private void FixedUpdate()
    {
        // Always reset cache
        totalGrav = 0;

        for (int i = 0; i < others.Count; i++)
        {
            // Only proceed if current Body is not actually yourself, and
            // ensure a Rigidbody is present
            if (others[i] != body && others[i].GetComponent<Rigidbody>())
            {
                Vector3 thisPos = body.transform.position;
                Vector3 otherPos = others[i].transform.position;

                // Distance (difference magnitude) between this and other object
                // float distance = Mathf.Sqrt(Mathf.Pow(thisPos.x - otherPos.x, 2) + Mathf.Pow(thisPos.y - otherPos.y, 2) + Mathf.Pow(thisPos.z - otherPos.z, 2));
                float distance = Vector3.Distance(thisPos, otherPos);

                // Magnitude (strength) of gravitational force
                float magnitude = Constants.G * (others[i].GetMass() * body.GetMass() / Mathf.Pow(distance, 2));
                totalGrav += magnitude;

                // Convert calculation into workable force
                // Normalised to turn the direction into a length of 1,
                // which is then amplified by the force magnitude
                Vector3 force = ((thisPos - otherPos).normalized * magnitude) * Time.fixedDeltaTime;

                // Apply force
                body.ApplyForce(-force);
            }
        }

        // Cache totalGrav into this Body in case it is needed further
        body.StoreGrav(totalGrav);
    }
}