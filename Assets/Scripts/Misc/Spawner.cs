using UnityEngine;

/// <summary>
/// Prefabricated GameObject spawner.
/// </summary>
public class Spawner : MonoBehaviour
{
    /// <summary>
    /// Prefabs you want to spawn.
    /// </summary>
    [SerializeField]
    private GameObject[] prefabs;

    /// <summary>
    /// Amount of GameObjects to spawn.
    /// </summary>
    [SerializeField]
    private float amount = 64;

    /// <summary>
    /// Maximum spawn distance magnitude for all dimensions.
    /// </summary>
    [SerializeField]
    private Vector3 spawnAxisMax = new Vector3(100, 100, 100);

    private void Start()
    {
        //If no prefabs given, just kill this script
        if (prefabs.Length == 0)
            Destroy(this);

        //Randomly spawn prefabs until we have the right amount
        for (int i = 0; i < amount; i++)
        {
            Vector3 randPos = new Vector3(
                Random.Range(-spawnAxisMax.x, spawnAxisMax.x),
                Random.Range(-spawnAxisMax.y, spawnAxisMax.y),
                Random.Range(-spawnAxisMax.z, spawnAxisMax.z));

            GameObject obj = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position + randPos, Quaternion.identity, transform);
            //obj.transform.parent = transform.parent;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 1);
        Gizmos.DrawCube(transform.position, spawnAxisMax * 2);
    }
} 