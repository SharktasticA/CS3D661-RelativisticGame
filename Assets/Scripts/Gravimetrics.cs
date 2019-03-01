using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.KArelativity;

/// <summary>
/// 
/// </summary>
public class Gravimetrics : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    List<Body> others = new List<Body>();

    private void Start()
    {
        //
        GameObject[] otherObjs = GameObject.FindGameObjectsWithTag("Body");

        //
        for (int i = 0; i < otherObjs.Length; i++)
            if (otherObjs[i].GetComponent<Body>())
                others.Add(otherObjs[i].GetComponent<Body>());
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < others.Count; i++)
        {
            //
            if (others[i] != GetComponent<Body>() && others[i].GetComponent<Rigidbody>())
            {
                Vector3 thisPos = GetComponent<Body>().GetPos();
                Vector3 otherPos = others[i].GetPos();

                //Distance (difference magnitude) between this and other object
                float distance = Mathf.Sqrt(Mathf.Pow(thisPos.x - otherPos.x, 2) + Mathf.Pow(thisPos.y - otherPos.y, 2) + Mathf.Pow(thisPos.z - otherPos.z, 2));

                //Magnitude (strength) of gravitational force
                float magnitude = Constants.G * (others[i].GetMass() * GetComponent<Body>().GetMass() / Mathf.Pow(distance, 2));

                //Convert calculation into workable force
                ///Normalised to turn the direction into a length of 1,
                //which is then amplified by the force magnitude
                Vector3 force = (thisPos - otherPos).normalized * magnitude;

                //Apply force
                //Need for static casting will be removed in future revisions
                GetComponent<Body>().ApplyForce(-force);
            }
        }
    }
}
