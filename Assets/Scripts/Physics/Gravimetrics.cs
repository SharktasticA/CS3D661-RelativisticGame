using System.Collections.Generic;
using UnityEngine;
using Assets;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Body))]
public class Gravimetrics : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private Body body;

    /// <summary>
    /// 
    /// </summary>
    List<Body> others = new List<Body>();

    private void Start()
    {
        body = GetComponent<Body>();

        //
        GameObject[] otherObjs = GameObject.FindGameObjectsWithTag("Body");

        //
        for (int i = 0; i < otherObjs.Length; i++)
            if (otherObjs[i].GetComponent<Body>())
                others.Add(otherObjs[i].GetComponent<Body>());
    }

    private void FixedUpdate()
    {
        float totalGrav = 0;

        for (int i = 0; i < others.Count; i++)
        {
            //
            if (others[i] != body && others[i].GetComponent<Rigidbody>())
            {
                Vector3 thisPos = body.GetPos();
                Vector3 otherPos = others[i].GetPos();

                //Distance (difference magnitude) between this and other object
                //float distance = Mathf.Sqrt(Mathf.Pow(thisPos.x - otherPos.x, 2) + Mathf.Pow(thisPos.y - otherPos.y, 2) + Mathf.Pow(thisPos.z - otherPos.z, 2));
                float distance = Vector3.Distance(thisPos, otherPos);

                //Magnitude (strength) of gravitational force
                float magnitude = Constants.G * (others[i].GetMass() * body.GetMass() / Mathf.Pow(distance, 2));
                totalGrav += magnitude;

                //Convert calculation into workable force
                ///Normalised to turn the direction into a length of 1,
                //which is then amplified by the force magnitude
                Vector3 force = (thisPos - otherPos).normalized * magnitude;

                //Apply force
                body.ApplyForce(-force);
            }
        }

        if (GetComponent<Ship>())
        {
            //Cache total gravity calculated so it can be referenced elsewhere
            GetComponent<Ship>().SetGrav(totalGrav);
        }
    }
}