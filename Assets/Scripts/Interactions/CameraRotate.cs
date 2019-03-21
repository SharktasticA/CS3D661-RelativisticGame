using UnityEngine;

/// <summary>
/// Allows camera's rotation to be controlled
/// by player.
/// </summary>
[RequireComponent(typeof(Camera))]
public class CameraRotate : MonoBehaviour
{
    /// <summary>
    /// Cached camera's original position.
    /// </summary>
    private Vector3 cameraOffset = new Vector3(0, 0, 0);

    /// <summary>
    /// Cached camera's original orientation.
    /// </summary>
    private Vector3 cameraRotate = new Vector3(0, 0, 0);

    /// <summary>
    /// Desired mouse responsiveness.
    /// </summary>
    [SerializeField]
    private float mouseSensitivity = 5f;

    private void Start()
    {
        cameraOffset = transform.position;
        cameraRotate = transform.rotation.eulerAngles;
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            transform.localPosition = cameraOffset;
            transform.localRotation = Quaternion.Euler(cameraRotate);
        }
        else if (Input.GetMouseButton(1))
        {
            transform.RotateAround(transform.parent.GetChild(0).position, Vector3.up, Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);
            transform.RotateAround(transform.parent.GetChild(0).position, Vector3.left, -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime);

            Quaternion finalRot = transform.rotation;
            finalRot.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            transform.rotation = finalRot;
        }
    }
}