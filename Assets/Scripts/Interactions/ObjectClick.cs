using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Ship))]
public class ObjectClick : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private GameObject clickedObjectMetre;

    /// <summary>
    /// 
    /// </summary>
    private Planet clickedObject;

    /// <summary>
    /// 
    /// </summary>
    private float timeout = 0;

    private void Start()
    {
        clickedObjectMetre = GameObject.FindGameObjectWithTag("ClickedObjectMetre");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Reset();

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                clickedObject = hit.collider.transform.parent.GetComponent<Planet>();
                timeout = 5f;
            }
        }

        if (timeout > 0) Draw();
        else Reset();
    }

    private void Draw()
    {
        clickedObjectMetre.transform.GetChild(0).GetComponent<Text>().text = "Selected: " + clickedObject.transform.name;

        float distance = Vector3.Distance(transform.position, clickedObject.GetPos()) - clickedObject.GetSize();
        clickedObjectMetre.transform.GetChild(1).GetComponent<Text>().text = "Distance: " + string.Format("{0:n0}", distance * 100) + "km";

        timeout -= 1 * Time.deltaTime;
    }

    private void Reset()
    {
        clickedObjectMetre.transform.GetChild(0).GetComponent<Text>().text = "";
        clickedObjectMetre.transform.GetChild(1).GetComponent<Text>().text = "";
        timeout = 0;
    }
}