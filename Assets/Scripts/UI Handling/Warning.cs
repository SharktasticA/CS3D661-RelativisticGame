using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Ship))]
public class Warning : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private GameObject warningLabel;

    /// <summary>
    /// 
    /// </summary>
    private Planet[] planets;

    private void Start()
    {
        warningLabel = GameObject.FindGameObjectWithTag("Warning");
        planets = FindObjectsOfType<Planet>();
    }

    private void Update()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            //*100 to convert into KM
            float distance = (Vector3.Distance(transform.position, planets[i].transform.position) - planets[i].GetLength()) * 100;

            if (distance <= 1000)
            {
                warningLabel.SetActive(true);
                return;
            }
            else
                warningLabel.SetActive(false);
        }
    }
}