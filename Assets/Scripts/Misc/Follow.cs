using UnityEngine;

public class Follow : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Body toFollow;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.LookAt(toFollow.transform);

        transform.Translate(Vector3.forward * ((toFollow.GetSpeed() * 0.975f) * Time.deltaTime));
    }
}
