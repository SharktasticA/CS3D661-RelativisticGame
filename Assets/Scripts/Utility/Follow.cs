using UnityEngine;

/// <summary>
/// Object follow script.
/// </summary>
public class Follow : MonoBehaviour
{
    /// <summary>
    /// Body entity to follow.
    /// </summary>
    [SerializeField]
    private Body toFollow;

    private void Update()
    {
        transform.LookAt(toFollow.transform);
        transform.Translate(Vector3.forward * ((toFollow.GetSpeed() * 0.975f) * Time.deltaTime));
    }
}