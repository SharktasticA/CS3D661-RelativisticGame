using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Screenshotter : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private int resX = 5120;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private int resY = 2880;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private int quality = 100;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private KeyCode captureKey = KeyCode.P;

    /// <summary>
    /// 
    /// </summary>
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(captureKey))
        {
            cam.targetTexture = new RenderTexture(resX, resY, 24);
            Texture2D ssTexture = new Texture2D(resX, resY, TextureFormat.RGB24, false);
            cam.Render();
            RenderTexture.active = cam.targetTexture;
            ssTexture.ReadPixels(new Rect(0, 0, resX, resY), 0, 0);

            Destroy(cam.targetTexture);
            cam.targetTexture = null;
            RenderTexture.active = null;

            byte[] bytes = ssTexture.EncodeToJPG(quality);
            string filename = string.Format("{0}/../Screenshots/{1}x{2}_{3}.jpg", Application.dataPath, resX, resY, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")); ;
            System.IO.File.WriteAllBytes(filename, bytes);
        }
    }
}
