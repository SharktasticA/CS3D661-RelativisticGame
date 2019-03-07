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
    protected float speed = 0;

    /// <summary>
    /// 
    /// </summary>
    private float grav = 0;

    /// <summary>
    /// 
    /// </summary>
    private Vector3 lastPos;

    /// <summary>
    /// 
    /// </summary>
    private float cooldown = 0.25f;

    private void FixedUpdate()
    {
        cooldown -= 1f * Time.fixedDeltaTime;
        if (cooldown <= 0f)
        {
            speed += (transform.position - lastPos).magnitude * Time.fixedDeltaTime;
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
    public float GetLength() { return (transform.GetChild(0).GetComponent<MeshFilter>().mesh.bounds.extents.z * transform.GetChild(0).localScale.z); }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetSpeed() { return speed; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetSpeedKMS() { return speed * 100; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetSpeedKPH() { return GetSpeedKMS() * 3600; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetGrav() { return grav * 100; }

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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="newLength"></param>
    public void SetLength(float newLength)
    {
        Vector3 newScale = new Vector3(
            transform.GetChild(0).localScale.x,
            transform.GetChild(0).localScale.y,
            newLength / transform.GetChild(0).GetComponent<MeshFilter>().mesh.bounds.extents.z);

        transform.GetChild(0).localScale = newScale;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="newGrav"></param>
    public void SetGrav(float newGrav) { grav = newGrav; }
}
