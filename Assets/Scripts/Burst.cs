using UnityEngine;

public class Burst : MonoBehaviour
{
    [Header("Particle Settings")]
    public ParticleSystem burstEffect;   // Player içindeki particle effect
    public float burstInterval = 0.5f;   // Kaç saniyede bir patlama olacak (Inspector’dan ayarlanabilir)

    private float burstTimer;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (burstTimer <= 0f)
            {
                PlayBurst();
                burstTimer = burstInterval;
            }
        }

        if (burstTimer > 0f)
        {
            burstTimer -= Time.deltaTime;
        }
    }

    void PlayBurst()
    {
        if (burstEffect != null)
        {
            burstEffect.Play();
        }
    }
}
