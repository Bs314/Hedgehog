using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    
    public ParticleSystem deathPartickles;
    
    public List<GameObject> pngList;
    //public AudioClip deathSound;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    public void DeathProtocol()
    {
        deathPartickles.transform.position = pngList[0].transform.position;
        //AudioSource.PlayClipAtPoint(deathSound,transform.position,5f);
        deathPartickles.Play();
        GetComponent<Animator>().enabled = false;


        for (int i = 0; i < pngList.Count ; i++)
        {
            pngList[i].SetActive(false);
        }

        
        Destroy(gameObject, 1f);
    }
}
