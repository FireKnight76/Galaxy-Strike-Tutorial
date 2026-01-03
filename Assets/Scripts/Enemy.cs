using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionParticles;
    [SerializeField] float hitPoints = 3f;
    [SerializeField] int scorePoints = 1;

    Scoreboard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHits();

    }

    void ProcessHits()
    {
        hitPoints--;

        if (hitPoints == 0)
        {
            scoreboard.IncreaseScore(scorePoints);
            Instantiate(explosionParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

}
