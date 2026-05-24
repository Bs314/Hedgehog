using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    private Vector3 respawnPoint;
    private bool isRespawn = false;
    public static bool isDeath = false; 
    public float reloadDelay = 2.1f;
    PlayerSoundManager playerSoundManager;
    void Start()
    {
        playerSoundManager = GetComponent<PlayerSoundManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "Damage" || collision.tag == "Enemy") && isDeath == false)
        {
            Debug.Log("die");
            GetComponent<ScreenFade>().StartFadeOut();
            isDeath = true;
            playerSoundManager.PlayDeathSounds();
            GetComponent<Animator>().SetTrigger("isDeath");
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;     
            Invoke("ReloadScene",reloadDelay);    
            
        }

        if(collision.tag == "RespawnPoint")
        {
            Debug.Log("Checkpoint");
            isRespawn = true;
            respawnPoint = collision.transform.position;
            collision.GetComponent<Animator>().SetTrigger("Activated");
        }
    }

    void ReloadScene()
    {
        if(isRespawn)
        {
            isDeath = false;  
            transform.position = respawnPoint;   
            GetComponent<Animator>().SetTrigger("respawn");   
            GetComponent<ScreenFade>().StartFadeIn();
            
        }
        else
        {
            isDeath = false;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex); 
        }
           
    }

    

    

}
