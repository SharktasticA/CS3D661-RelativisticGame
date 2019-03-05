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

    private void Start()
    {
        body = GetComponent<Body>();
        startMass = GetComponent<Body>().GetMass();
    }

    private void FixedUpdate()
    {
        //
        body.SetMass(startMass / Lorentz(body.GetSpeedKMS()));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="V"></param>
    /// <returns></returns>
    public float Lorentz(float V)
    {
        float beta = Mathf.Sqrt(1f - Mathf.Pow(V / Constants.C, 2));
        return beta;
    }
}