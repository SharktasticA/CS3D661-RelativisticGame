using System.Collections.Generic;
using UnityEngine;
using Assets;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Body))]
public class Relativistics : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private Body body;

    /// <summary>
    /// 
    /// </summary>
    private float startMass;

    /// <summary>
    /// 
    /// </summary>
    private float startLength;

    private void Start()
    {
        body = GetComponent<Body>();
        startMass = GetComponent<Body>().GetMass();
        startLength = GetComponent<Body>().GetLength();
    }

    private void FixedUpdate()
    {
        //
        float beta = Lorentz(body.GetSpeedKMS());

        //
        float R = startMass / beta;
        if (!float.IsNaN(R))
            body.SetMass(R);

        //
        float L = startLength * beta;
        if (!float.IsNaN(L))
            body.SetLength(L);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="V"></param>
    /// <returns></returns>
    public float Lorentz(float V) { return Mathf.Sqrt(1f - Mathf.Pow(V / Constants.C, 2)); }
}