using UnityEngine;
using Unity.Cinemachine;

public class SpikeMover : MonoBehaviour
{
    public float moveSpeed = 5f; // Lerp speed (Inspector’dan ayarlanabilir)
    public float spikeDestroyTime = 5f;
    public PolygonCollider2D  pc2d;
    public AudioSource audioSource;
    public AudioClip stickSound;
    public CinemachineImpulseSource cinemachineImpulseSource;
    private Vector2 targetPoint;
    private bool hasTarget = false;
    private bool isShaked = false;

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
                if(isShaked == false)
                {
                    isShaked = true;
                    cinemachineImpulseSource.GenerateImpulse(); 
                    audioSource.PlayOneShot(stickSound);
                    
                }
                
                pc2d.isTrigger = false;
                Destroy(gameObject, spikeDestroyTime);
            }
        }
    }

    

}
