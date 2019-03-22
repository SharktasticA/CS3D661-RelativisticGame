using UnityEngine;

/// <summary>
/// Movement illusion field generator.
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public class Starfield : MonoBehaviour
{
    /// <summary>
    /// Internal reference to the ship that the starfield
    /// will generate around.
    /// </summary>
    private Ship ship;

    /// <summary>
    /// Number of starts to generate.
    /// </summary>
    [SerializeField]
    private int maxStars = 2560;

    /// <summary>
    /// Size each particle will be.
    /// </summary>
    [SerializeField]
    private float starSize = 0.01f;

    /// <summary>
    /// Field size that stars will be generated within.
    /// </summary>
    [SerializeField]
    private float fieldDiametre = 100f;

    /// <summary>
    /// How close should stars be to the ship.
    /// </summary>
    [SerializeField]
    private float clipLimit = 2.5f;

    /// <summary>
    /// Local reference to that generates the starfield.
    /// </summary>
    private ParticleSystem particles;

    /// <summary>
    /// Reference to all stars.
    /// </summary>
    private ParticleSystem.Particle[] stars;

    /// <summary>
    /// Generates the starfield from scratch.
    /// </summary>
    private void createStars()
    {
        // For every start, randomise the position and colour alpha
        for (int i = 0; i < maxStars; i++)
        {
            float randX = Random.Range(-(fieldDiametre / 2), (fieldDiametre / 2));
            float randY = Random.Range(-(fieldDiametre / 2), (fieldDiametre / 2));
            float randZ = Random.Range(-(fieldDiametre / 2), (fieldDiametre / 2));

            stars[i].position = new Vector3(randX, randY, randZ);
            stars[i].startSize = starSize;
            stars[i].startColor = new Color(255, 255, 255, Random.Range(155, 255));
        }
        particles.SetParticles(stars, stars.Length);
    }

    private void Start()
    {
        if (!GetComponent<ParticleSystem>())
            Destroy(this);

        particles = GetComponent<ParticleSystem>();
        stars = new ParticleSystem.Particle[maxStars];

        ship = FindObjectOfType<Ship>();
        transform.position = ship.transform.position;
    }

    private void Update()
    {
        // If no particle system reference, return 
        if (particles == null) createStars();
        
        if (Vector3.Distance(transform.position, ship.transform.position) > 100) transform.position = new Vector3(0, 0, 0);

        for (int i = 0; i < maxStars; i++)
        {
            // Get current distance between particle and ship's point of origin
            float starDist = Vector3.Distance(stars[i].position, ship.transform.position);

            if (starDist > fieldDiametre)
            {
                // If this distance is now beyond the field diametre,
                // re-randomise the particle's location

                float randX = Random.Range(-(fieldDiametre / 2), (fieldDiametre / 2));
                float randY = Random.Range(-(fieldDiametre / 2), (fieldDiametre / 2));
                float randZ = Random.Range(-(fieldDiametre / 2), (fieldDiametre / 2));

                stars[i].position = new Vector3(randX, randY, randZ) + ship.transform.position;
            }

            // If the paricle is within clipping instance, make
            // it colourless
            if (starDist < clipLimit)
                stars[i].startColor = new Color(0, 0, 0, 0);
            else
                stars[i].startColor = new Color(255, 255, 255, Random.Range(155, 255));
        }

        // Re-set particles after adjustments
        particles.SetParticles(stars, stars.Length);
    }
}