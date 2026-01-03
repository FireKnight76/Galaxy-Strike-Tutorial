using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
