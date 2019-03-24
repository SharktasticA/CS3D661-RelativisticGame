using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class ChangeScene : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private int sceneIndex;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private bool isAnyKey = false;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private KeyCode cueKey = KeyCode.Space;

    private void Update()
    {
        if (isAnyKey)
        {
            if (Input.anyKey)
                SceneManager.LoadSceneAsync(sceneIndex);
        }
        else
        {
            if (Input.GetKey(cueKey))
                SceneManager.LoadSceneAsync(sceneIndex);
        }
    }
}
