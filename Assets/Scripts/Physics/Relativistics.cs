using UnityEngine;
using Assets;

/// <summary>
/// Relativistic physics simulation.
/// </summary>
[RequireComponent(typeof(Body))]
public class Relativistics : MonoBehaviour
{
    /// <summary>
    /// Internal reference to body to apply effects to.
    /// </summary>
    private Body body;

    /// <summary>
    /// Cached start mass from the body.
    /// </summary>
    private float startMass;

    /// <summary>
    /// Cached start length from the body.
    /// </summary>
    private float startLength;

    /// <summary>
    /// Cached Lorentz factor result.
    /// </summary>
    private float beta;

    private void Start()
    {
        body = GetComponent<Body>();
        startMass = GetComponent<Body>().GetMass();
        startLength = GetComponent<Body>().GetLength();
    }

    private void FixedUpdate()
    {
        if (body)
        {
            // Get relativistic mass and length values
            float rMass = M(startMass, Beta(body.GetSpeedKMS()));
            float rlength = L(startLength, Beta(body.GetSpeedKMS() / 10));

            // If value isn't invalid, apply R to body
            if (!float.IsNaN(rMass))
                body.SetMass(rMass);

            // Due to floating origin, only the ship can experience length contraction
            if (body.GetComponentInChildren<Ship>())
            {
                //If value isn't invalid, apply L to body/ship
                if (!float.IsNaN(rlength))
                    body.SetLength(rlength);
            }
        }
    }

    /// <summary>
    /// Evaulates current Lorentz factor for body with default speed of light constant.
    /// </summary>
    /// <param name="v">Body's current velocity magnitude.</param>
    public float Beta(float v) { return Mathf.Sqrt(1f - Mathf.Pow(v / Constants.c, 2)); }

    /// <summary>
    /// Evaulates current Lorentz factor for body with custom speed of light constant.
    /// </summary>
    /// <param name="v">Body's current velocity magnitude.</param>
    /// <param name="c">Custom speed of light.</param>
    public float Beta(float v, float c) { return Mathf.Sqrt(1f - Mathf.Pow(v / c, 2)); }

    /// <summary>
    /// Returns calculated relativistic mass based on given mass and Lorentz factor.
    /// </summary>
    /// <param name="m">Body's actual/rest mass.</param>
    /// <param name="b">Lorentz factor beta.</param>
    public float M(float m, float b) { return m / b; }

    /// <summary>
    /// Returns calculated observer time based on given proper time and Lorentz factor.
    /// </summary>
    /// <param name="t">Proper time.</param>
    /// <param name="b">Lorentz factor beta.</param>
    public float T(float t, float b) { return t / b; }

    /// <summary>
    /// Returns calculated contracted length based on given length and Lorentz factor.
    /// </summary>
    /// <param name="l">Body's actual/rest length in direction of travel.</param>
    /// <param name="b">Lorentz factor beta.</param>
    public float L(float l, float b) { return l * b; }
}