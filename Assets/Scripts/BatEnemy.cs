using UnityEngine;
using System.Collections;

public class BatEnemy : MonoBehaviour
{
    
    public enum BatState { Sleep, Chase }
    public BatState currentState = BatState.Sleep;
    [Header("PNGs")]
    public GameObject batSleep;
    public GameObject batChasing;
    public GameObject leftWing;
    public GameObject rightWing;



    [Header("Script Options")]
    public Transform player;
    public float detectionThreshold = 5f;
    public float checkInterval = 0.5f;
    public float chaseSpeed = 3f;
    public Animator animator;

    private void Start()
    {
        batSleep.SetActive(true);
        batChasing.SetActive(false);
        leftWing.SetActive(false);
        rightWing.SetActive(false);

        InvokeRepeating(nameof(CheckDistanceToPlayer), checkInterval, checkInterval);
    }

    void CheckDistanceToPlayer()
    {
        if (currentState != BatState.Sleep) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < detectionThreshold)
        {
            batSleep.SetActive(false);
            batChasing.SetActive(true);
            leftWing.SetActive(true);
            rightWing.SetActive(true);
            animator.enabled = true;
            currentState = BatState.Chase;
            CancelInvoke(nameof(CheckDistanceToPlayer));
            StartCoroutine(ChaseRoutine());
        }
    }

    IEnumerator ChaseRoutine()
    {
        while (currentState == BatState.Chase)
        {
            
            Vector2 targetPos = player.position;

            // O konuma doğru ilerle
            while ((Vector2)transform.position != targetPos)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    targetPos,
                    chaseSpeed * Time.deltaTime
                );
                yield return null;
            }

            // 0.5 saniye bekle, sonra tekrar yeni konumu al
            yield return new WaitForSeconds(checkInterval);
        }
    }

    void OnDrawGizmos()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,detectionThreshold);
        
        
    }
}
