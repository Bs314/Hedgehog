using UnityEngine;

public class Burst : MonoBehaviour
{
    [Header("Particle Settings")]
    public ParticleSystem burstEffect;   
    public float burstInterval = 0.5f;   
    
    [Header("Damage Settings")]
    public float radius = 5f;        
    public int damage = 10;          
    public LayerMask enemyLayer;     

    private float burstTimer;
    public Animator animator;
    public AudioClip bugSmashSound;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if ((Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftControl)) && !CollisionHandler.isDeath && !TimelineSignal.freezePlayer)
        {
            if (burstTimer <= 0f)
            {
                PlayBurst();
                burstTimer = burstInterval;
                animator.SetBool("isBurst",true);
            }
        
        }
        if(Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("isBurst",false);    
        }

        if (burstTimer > 0f)
        {
            burstTimer -= Time.deltaTime;
        }
    }

    void PlayBurst()
    {
        DoAreaDamage();
        if (burstEffect != null)
        {
            burstEffect.Play();
        }
    }

    void DoAreaDamage()
    {
        // Belirtilen yarıçapta düşmanları bul
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);

        foreach (Collider2D enemy in enemies)
        {
            
            EnemyDeathHandler enemyDeathHandler = enemy.transform.parent.GetComponent<EnemyDeathHandler>();
            if(enemyDeathHandler == null)
            enemyDeathHandler = enemy.GetComponent<EnemyDeathHandler>();
            audioSource.PlayOneShot(bugSmashSound);
            enemyDeathHandler.DeathProtocol();
            
            /*
            Destroy(enemy.gameObject);
            Animator enemyAnimator = enemy.transform.parent.GetComponent<Animator>();
            if(enemyAnimator!=null)
            {
                enemyAnimator.enabled = false;
            }
            */
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);    
    }
}
