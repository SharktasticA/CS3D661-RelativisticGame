using UnityEngine;

/// <summary>
/// Body-subclass for scene space station objects.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
class Station : Body
{
    /// <summary>
    /// Reference to possible object to make the station
    /// face towards.
    /// </summary>
    [SerializeField]
    private GameObject target;

    /// <summary>
    /// Degree tilt for when target is given.
    /// </summary>
    [SerializeField]
    private float tilt = 45;

    private void Start()
    {
        if (!target)
            target = GameObject.FindGameObjectWithTag("Sun");
    }

    private void Update()
    {
        if (target)
        {
            transform.LookAt(target.transform);
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, target.transform.position - transform.position, 100f * Time.deltaTime, 0.0f))
                * Quaternion.Euler(new Vector3(tilt, 0, 0));
        }
    }
}