/*
	Based on: http://wiki.unity3d.com/index.php/Floating_Origin
*/

using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Camera))]
public class FloatingOrigin : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public float threshold = 100.0f;

    /// <summary>
    /// Set to zero to disable
    /// </summary>
    public float physicsThreshold = 1000.0f;

    /// <summary>
    /// 
    /// </summary>
    public float defaultSleepThreshold = 0.14f;

    void LateUpdate()
    {
        Vector3 camPos = gameObject.transform.position;
        camPos.y = 0f;

        if (camPos.magnitude > threshold)
        {
            Transform[] objs = FindObjectsOfType<Transform>();
            foreach (Transform t in objs)
                if (!t.parent)
                    t.position -= camPos;
        }

        if (physicsThreshold > 0f)
        {
            float thresholdSqr = physicsThreshold * physicsThreshold; // simplify check on threshold
            Rigidbody[] objs = FindObjectsOfType<Rigidbody>();

            foreach (Rigidbody rb in objs)
            {
                if (rb.gameObject.transform.position.sqrMagnitude > thresholdSqr)
                    rb.sleepThreshold = float.MaxValue;
                else
                    rb.sleepThreshold = defaultSleepThreshold;
            }
        }
    }
}