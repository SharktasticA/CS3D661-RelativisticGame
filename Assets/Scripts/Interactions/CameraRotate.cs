using UnityEngine;

/// <summary>
/// 
/// </summary>
public class CameraRotate : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private Vector3 cameraOffset = new Vector3(0, 0, 0);

    /// <summary>
    /// 
    /// </summary>
    private Vector3 cameraRotate = new Vector3(0, 0, 0);

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float mouseSensitivity = 5f;

    private void Start()
    {
        cameraOffset = transform.position;
        cameraRotate = transform.rotation.eulerAngles;
        //transform.RotateAround(transform.parent.GetChild(0).position, Vector3.up, Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);
    }

    /// <summary>
    /// 
    /// </summary>
    private void ManageCamera()
    {
        if (Input.GetKeyDown(0))
        {
            transform.position = cameraOffset;
            transform.rotation = Quaternion.Euler(cameraRotate);
        }
        else if (Input.GetMouseButton(1))
        {
            transform.RotateAround(transform.parent.GetChild(0).position, Vector3.up, Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);
            transform.RotateAround(transform.parent.GetChild(0).position, Vector3.left, Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime);

            Quaternion finalRot = transform.rotation;
            finalRot.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            transform.rotation = finalRot;
        }
    }

    private void LateUpdate()
    {
        ManageCamera();
    }
}