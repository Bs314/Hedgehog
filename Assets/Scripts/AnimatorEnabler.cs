using UnityEngine;

public class AnimatorEnabler : MonoBehaviour
{
    
    public float delay = 0;
    Animator animator;

    void Start()
    {
         animator = GetComponent<Animator>();   
    }

    
    void Update()
    {
        if(delay>0)
        {
            delay -= Time.deltaTime;
            if(delay<=0)
            {
                animator.enabled = true;   
            }    
        }
            
    }
}
