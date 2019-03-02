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
    private float posSpeed = 50f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float rotSpeed = 25f;

    private void Start()
    {
        player = GetComponent<Body>();
    }

    private void Update()
    {
        //
        if (!player) return;

        //
        if (Input.GetKey(KeyCode.W))
        {
            float currentX = player.GetRot().eulerAngles.x;
            float changeRot = -rotSpeed * Time.deltaTime;

            if (currentX == 0 || currentX <= 30 || currentX + changeRot > 330f)
                player.SetRot(Quaternion.Euler(
                    currentX + changeRot,
                    player.GetRot().eulerAngles.y,
                    player.GetRot().eulerAngles.z));
        }

        //
        if (Input.GetKey(KeyCode.S))
        {
            float currentX = player.GetRot().eulerAngles.x;
            float changeRot = rotSpeed * Time.deltaTime;

            if (currentX == 0 || currentX >= 330f || currentX + changeRot < 30f)
                player.SetRot(Quaternion.Euler(
                    currentX + changeRot,
                    player.GetRot().eulerAngles.y,
                    player.GetRot().eulerAngles.z));
        }
    }
}
