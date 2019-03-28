using UnityEngine;

/// <summary>
/// 
/// </summary>
public class MenuToggle : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private GameObject menu;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private bool startHidden = false;

    private void Start()
    {
        if (!menu)
            Destroy(this);

        if (startHidden) HideMenu();
        else ShowMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.GetComponent<CanvasGroup>().alpha == 0f) ShowMenu();
            else HideMenu();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void ShowMenu()
    {
        menu.GetComponent<CanvasGroup>().blocksRaycasts = menu.GetComponent<CanvasGroup>().interactable = true;
        menu.GetComponent<CanvasGroup>().alpha = 1;
    }

    /// <summary>
    /// 
    /// </summary>
    public void HideMenu()
    {
        menu.GetComponent<CanvasGroup>().blocksRaycasts = menu.GetComponent<CanvasGroup>().interactable = false;
        menu.GetComponent<CanvasGroup>().alpha = 0;
    }
}
