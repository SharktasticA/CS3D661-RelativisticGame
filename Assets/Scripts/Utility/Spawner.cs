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
    /// Naming convention for the object's
    /// transform name.
    /// </summary>
    [SerializeField]
    private string nomenclature = "Asteroid";

    /// <summary>
    /// Maximise size modifier percentage
    /// for scale randomisation.
    /// </summary>
    [SerializeField]
    private float randSizeMaxPct = 5f;

    /// <summary>
    /// Amount of GameObjects to spawn.
    /// </summary>
    [SerializeField]
    private float amount = 64;

    /// <summary>
    /// Maximum spawn distance magnitude for all dimensions.
    /// </summary>
    [SerializeField]
    private Vector3 spawnAxisMax = new Vector3(128, 128, 128);

    private void Awake()
    {
        // If no prefabs given, just kill this script
        if (prefabs.Length == 0)
            Destroy(this);

        // Randomly spawn prefabs until we have the right amount
        for (int i = 0; i < amount; i++)
        {
            Vector3 randPos = new Vector3(
                Random.Range(-spawnAxisMax.x, spawnAxisMax.x),
                Random.Range(-spawnAxisMax.y, spawnAxisMax.y),
                Random.Range(-spawnAxisMax.z, spawnAxisMax.z));

            Vector3 randRot = new Vector3(
                Random.Range(0, 359),
                Random.Range(0, 359),
                Random.Range(0, 359));

            GameObject obj = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position + randPos, Quaternion.identity * Quaternion.Euler(randRot), transform);
            obj.transform.localScale *= Random.Range(-randSizeMaxPct, randSizeMaxPct);
            obj.transform.name = nomenclature + "-" + Random.Range(0, 99999);
        }
    }

    /// <summary>
    /// Allows the spawn field to be visisble in inspector.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 1);
        Gizmos.DrawCube(transform.position, spawnAxisMax * 2);
    }
} 