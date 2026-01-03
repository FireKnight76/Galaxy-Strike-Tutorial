using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionParticles;

    private void OnParticleCollision(GameObject other)
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(gameObject); 
        //var explosion = explosionParticles.GetComponent<ParticleSystem>().emission;
        //explosion.enabled = true;
    }
}
