using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Allows user to select object in scene.
/// </summary>
[RequireComponent(typeof(Ship))]
public class ObjectClick : MonoBehaviour
{
    /// <summary>
    /// Local reference to UI element that holds the
    /// Text display.
    /// </summary>
    private GameObject clickedObjectMetre;

    /// <summary>
    /// Cached reference to last object that has been
    /// clicked.
    /// </summary>
    private Body clickedObject;

    /// <summary>
    /// How long it takes to timeout the UI text.
    /// </summary>
    [SerializeField]
    private float timeout = 10f;

    /// <summary>
    /// Internal countdown for when an object has
    /// been clicked.
    /// </summary>
    private float countDown = 0;

    private void Start()
    {
        clickedObjectMetre = GameObject.FindGameObjectWithTag("ClickedObjectMetre");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Undraw();

            // Attempt raycast towards where cursor is
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // If collider hit and is Body, grab ref to it
            if (Physics.Raycast(ray, out hit))
            {
                // If the user clicked the ship, just do
                // nothing
                if (hit.collider.GetComponent<Ship>())
                    return;

                if (hit.collider.transform.parent.GetComponent<Body>())
                {
                    clickedObject = hit.collider.transform.parent.GetComponent<Body>();
                    countDown = timeout;
                }
            }
        }

        if (countDown > 0 && clickedObject != null) Draw();
        else Undraw();   
    }

    /// <summary>
    /// Instructs UI text element to display data
    /// on the clicked object.
    /// </summary>
    private void Draw()
    {
        clickedObjectMetre.transform.GetChild(0).GetComponent<Text>().text = "Selected: " + clickedObject.transform.name;

        float distance = Vector3.Distance(transform.position, clickedObject.transform.position) - clickedObject.GetLength();
        if (clickedObject.GetComponent<Planet>())
            clickedObjectMetre.transform.GetChild(1).GetComponent<Text>().text = "Distance: " + string.Format("{0:n0}", distance * 1000) + "km";

        countDown -= 1 * Time.deltaTime;
    }

    /// <summary>
    /// Instructs Ui text element to clear itself.
    /// </summary>
    private void Undraw()
    {
        clickedObjectMetre.transform.GetChild(0).GetComponent<Text>().text = "";
        clickedObjectMetre.transform.GetChild(1).GetComponent<Text>().text = "";
        countDown = 0;
    }
}