using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Movement : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private Body player;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float maxSpeed = 1000f;

    private void Start()
    {
        player = GetComponent<Body>();
    }

    private void Update()
    {
        //
        if (!player) return;

        //
        if (Input.GetKey(KeyCode.Q))
            player.ApplyTorque(new Vector3(0, -0.0125f * Time.deltaTime, 0));
        if (Input.GetKey(KeyCode.E))
            player.ApplyTorque(new Vector3(0, 0.0125f * Time.deltaTime, 0));

        //
        player.ApplyForce(new Vector3(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, 0, 0));

        //
        player.ApplyForce(new Vector3(0, 0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime));
    }
}
