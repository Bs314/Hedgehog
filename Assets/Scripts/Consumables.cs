using UnityEngine;

public class Consumables : MonoBehaviour
{
   public bool isDoubleJump = false;
   public bool isDash = false;
   public bool isBurstSpike = false;
   public bool isSpikeShooter = false;



    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(isDoubleJump && !isDash && !isBurstSpike && !isSpikeShooter)
            {
                Jump jump = collision.GetComponent<Jump>();
                jump.ActivateDoubleJump();
                Debug.Log("DOUBLE_JUMP Activated!");
            }

            if(!isDoubleJump && isDash && !isBurstSpike && !isSpikeShooter)
            {
                Dash dash = collision.GetComponent<Dash>();
                dash.enabled = true; 
                Debug.Log("DASH Activated!");      
            }

            if(!isDoubleJump && !isDash && isBurstSpike && !isSpikeShooter)
            {
                Burst burst = collision.GetComponent<Burst>();
                burst.enabled = true;   
                Debug.Log("SPIKE_BURST Activated!");  
            }

            if(!isDoubleJump && !isDash && !isBurstSpike && isSpikeShooter)
            {
                SpikeShooter spikeShooter = collision.GetComponent<SpikeShooter>();
                spikeShooter.enabled = true;
                Debug.Log("SPIKE_SHOOTER Activated!"); 
            }

            Destroy(gameObject);


        }

    }

}
