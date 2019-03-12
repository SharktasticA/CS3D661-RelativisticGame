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
    private int maxStars = 2560;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float starSize = 0.01f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float fieldDiametre = 100f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float clipLimit = 1f;

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
            float randX = Random.Range(-(fieldDiametre / 2), (fieldDiametre / 2));
            float randY = Random.Range(-(fieldDiametre / 2), (fieldDiametre / 2));
            float randZ = Random.Range(-(fieldDiametre / 2), (fieldDiametre / 2));

            stars[i].position = new Vector3(randX, randY, randZ);
            stars[i].startSize = starSize;
            stars[i].startColor = new Color(255, 255, 255, Random.Range(155, 255));
        }

        //
        particles.SetParticles(stars, stars.Length);
    }

    private void Start()
    {
        ship = FindObjectOfType<Ship>();
        transform.position = ship.transform.position;
    }

    private void Update()
    {
        //
        if (particles == null) createStars();
        
        if (Vector3.Distance(transform.position, ship.transform.position) > 100) transform.position = new Vector3(0, 0, 0);

        for (int i = 0; i < maxStars; i++)
        {
            //
            float starDist = Vector3.Distance(stars[i].position, ship.transform.position);

            //
            if (starDist > fieldDiametre)
            {
                float randX = Random.Range(-(fieldDiametre / 2), (fieldDiametre / 2));
                float randY = Random.Range(-(fieldDiametre / 2), (fieldDiametre / 2));
                float randZ = Random.Range(-(fieldDiametre / 2), (fieldDiametre / 2));

                stars[i].position = new Vector3(randX, randY, randZ) + ship.transform.position;
            }

            //
            if (starDist < clipLimit)
                stars[i].startColor = new Color(0, 0, 0, 0);
            else
                stars[i].startColor = new Color(255, 255, 255, Random.Range(155, 255));
        }

        //
        particles.SetParticles(stars, stars.Length);
    }
}