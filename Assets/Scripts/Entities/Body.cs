using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Body : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private Vector3 lastPos;

    /// <summary>
    /// 
    /// </summary>
    protected float speed = 0;

    /// <summary>
    /// 
    /// </summary>
    private float cooldown = 0.25f;

    private void FixedUpdate()
    {
        cooldown -= 1f * Time.fixedDeltaTime;
        if (cooldown <= 0f)
        {
            speed = (transform.position - lastPos).magnitude * Time.fixedDeltaTime;
            lastPos = transform.position;
            cooldown = 0.25f;
        }
    }

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
    /// <returns></returns>
    public float GetSpeedKMS() { return speed * 10000; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetSpeedKPH() { return GetSpeedKMS() * 3600; }

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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="newMass"></param>
    public void SetMass(float newMass) { GetComponent<Rigidbody>().mass = newMass; }
}
