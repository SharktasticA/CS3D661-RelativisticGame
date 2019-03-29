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
        if (cueKey == KeyCode.None)
            return;

        if (isAnyKey)
        {
            if (Input.anyKey)
                SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            if (Input.GetKey(cueKey))
                SceneManager.LoadScene(sceneIndex);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
