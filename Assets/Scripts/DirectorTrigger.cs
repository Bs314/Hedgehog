using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class DirectorTrigger : MonoBehaviour
{
    public  PlayableDirector director;
    private bool isTriggered = false;
    void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player" && !isTriggered)
        {
            director.Play();    
            isTriggered = true;
        }
    }
}
