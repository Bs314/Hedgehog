using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    public float reloadDelay = 2f;
    PlayerSoundManager playerSoundManager;
    void Start()
    {
        playerSoundManager = GetComponent<PlayerSoundManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Damage")
        {

            Debug.Log("die");
            DisableMovements();
            Invoke("ReloadScene",reloadDelay);
            
            
        }

        if(collision.tag == "Enemy")
        {
            Debug.Log("die");
            DisableMovements();
            Invoke("ReloadScene",reloadDelay);
        }
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);    
    }

    void DisableMovements()
    {
        playerSoundManager.PlayDeathSounds();
        GetComponent<Animator>().SetTrigger("isDeath");
        GetComponent<Movement>().enabled = false;
        GetComponent<Dash>().enabled = false;
        GetComponent<Jump>().enabled = false;
        GetComponent<SpikeShooter>().enabled = false;
        GetComponent<Burst>().enabled = false;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        GetComponent<ScreenFade>().StartFadeOut();

    }
}
