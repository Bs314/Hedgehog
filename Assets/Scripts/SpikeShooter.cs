using UnityEngine;

public class SpikeShooter : MonoBehaviour
{
    [Header("Spike Settings")]
    public GameObject spikePrefab;
    public Transform spawnPoint;
    public float fireRate = 0.5f;   // Time between spikes
    public float rayDistance = 30f;
    public LayerMask hitLayers;

    private float fireTimer = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !CollisionHandler.isDeath && !TimelineSignal.freezePlayer)
        {
            if (fireTimer <= 0f)
            {
                ShootSpike();
                fireTimer = fireRate;
            }
        }

        if (fireTimer > 0f)
            fireTimer -= Time.deltaTime;
    }

    void ShootSpike()
    {
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayDistance, hitLayers);

        if (hit.collider != null)
        {
            Vector2 targetPoint = hit.point;

            GameObject spike = Instantiate(spikePrefab, spawnPoint.position, Quaternion.identity);
            GetComponent<Animator>().SetTrigger("isShoot");
            
            SpikeMover mover = spike.GetComponent<SpikeMover>();
            if (mover != null)
            {   
                mover.SetDirection(direction.x);
                mover.SetTarget(targetPoint);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        Gizmos.DrawLine(spawnPoint.position, transform.position + (Vector3)direction * rayDistance);

        if (spawnPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(spawnPoint.position, 0.05f);
        }
    }

}
