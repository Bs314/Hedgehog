using UnityEngine;

public class SpikeMover : MonoBehaviour
{
    public float moveSpeed = 5f; // Lerp speed (Inspector’dan ayarlanabilir)
    public float spikeDestroyTime = 5f;
    public PolygonCollider2D  pc2d;
    private Vector2 targetPoint;
    private bool hasTarget = false;

    public void SetTarget(Vector2 point)
    {
        targetPoint = point;
        hasTarget = true;
    }
    public void SetDirection(float d)
    {
        transform.localScale = new Vector3(transform.localScale.x * d, transform.localScale.y, transform.localScale.z);
    }

    void Update()
    {
        if (hasTarget)
        {
            if (Vector2.Distance(transform.position, targetPoint) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
            }
            else
            {
                pc2d.isTrigger = false;
                Destroy(gameObject, spikeDestroyTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
