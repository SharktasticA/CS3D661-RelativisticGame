using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Body : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Vector3 GetPos() { return transform.position; }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Quaternion GetRot() { return transform.rotation; }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Vector3 GetScale() { return transform.localScale; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetMass() { return GetComponent<Rigidbody>().mass; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="incomingForce"></param>
    /// <returns></returns>
    public bool ApplyForce(Vector3 incomingForce)
    {
        if (!GetComponent<Rigidbody>()) return false;
        GetComponent<Rigidbody>().AddForce(incomingForce, ForceMode.Force);
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="incomingTorque"></param>
    /// <returns></returns>
    public bool ApplyTorque(Vector3 incomingTorque)
    {
        if (!GetComponent<Rigidbody>()) return false;
        GetComponent<Rigidbody>().AddTorque(incomingTorque, ForceMode.Force);
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="newRot"></param>
    public void SetRot(Quaternion newRot) { transform.rotation = newRot; }
}
