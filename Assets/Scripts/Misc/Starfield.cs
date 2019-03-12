using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public class Starfield : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private Ship ship;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private int maxStars = 1024;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float starSize = 0.01f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float fieldDiametre = 5f;

    /// <summary>
    /// 
    /// </summary>
    private ParticleSystem particles;

    /// <summary>
    /// 
    /// </summary>
    private ParticleSystem.Particle[] stars;

    /// <summary>
    /// 
    /// </summary>
    private void createStars()
    {
        particles = GetComponent<ParticleSystem>();
        stars = new ParticleSystem.Particle[maxStars];

        //
        for (int i = 0; i < maxStars; i++)
        {
            float randX = Random.Range(-fieldDiametre, fieldDiametre);
            float randY = Random.Range(-fieldDiametre, fieldDiametre);
            float randZ = Random.Range(-fieldDiametre, fieldDiametre);

            stars[i].position = new Vector3(randX, randY, randZ);
            stars[i].startSize = starSize;
            stars[i].startColor = new Color(255, 255, 255, Random.Range(200, 255));
        }

        //
        particles.SetParticles(stars, stars.Length);
    }

    private void Start()
    {
        ship = FindObjectOfType<Ship>();
        transform.position = ship.transform.position;
        transform.rotation = ship.transform.rotation;
    }

    private void Update()
    {
        //
        if (particles == null) createStars();

        //if (Vector3.Distance(transform.position, ship.transform.position) > fieldDiametre) transform.position = ship.transform.position;

        for (int i = 0; i < maxStars; i++)
        {
            //
            if (Mathf.Pow(Vector3.Distance(stars[i].position, ship.transform.position), 2) > Mathf.Pow(fieldDiametre, 2))
            {
                float randX = Random.Range(-fieldDiametre, fieldDiametre);
                float randY = Random.Range(-fieldDiametre, fieldDiametre);
                float randZ = Random.Range(-fieldDiametre, fieldDiametre);

                stars[i].position = new Vector3(randX, randY, randZ) + ship.transform.position;
            }
        }

        //
        particles.SetParticles(stars, stars.Length);
    }
}