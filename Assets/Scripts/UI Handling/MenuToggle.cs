using UnityEngine;

/// <summary>
/// Allows a menu to be toggled in and out
/// of view without disabling the GameObject.
/// </summary>
public class MenuToggle : MonoBehaviour
{
    /// <summary>
    /// Reference to menu the code is going to
    /// toggle.
    /// </summary>
    [SerializeField]
    private GameObject menu;

    /// <summary>
    /// Flags whether the menu needs to be hidden
    /// at launch.
    /// </summary>
    [SerializeField]
    private bool startHidden = false;

    /// <summary>
    /// Specifies which keys toggles with menu.
    /// </summary>
    [SerializeField]
    private KeyCode cueKey = KeyCode.Escape;

    private void Start()
    {
        if (!menu)
            Destroy(this);

        if (startHidden) HideMenu();
        else ShowMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(cueKey))
        {
            if (menu.GetComponent<CanvasGroup>().alpha == 0f) ShowMenu();
            else HideMenu();
        }
    }

    /// <summary>
    /// Shows this menu.
    /// </summary>
    public void ShowMenu()
    {
        menu.GetComponent<CanvasGroup>().blocksRaycasts = menu.GetComponent<CanvasGroup>().interactable = true;
        menu.GetComponent<CanvasGroup>().alpha = 1;
    }

    /// <summary>
    /// Hides this menu.
    /// </summary>
    public void HideMenu()
    {
        menu.GetComponent<CanvasGroup>().blocksRaycasts = menu.GetComponent<CanvasGroup>().interactable = false;
        menu.GetComponent<CanvasGroup>().alpha = 0;
    }
}
