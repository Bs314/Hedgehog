using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    ScreenFade sf;
    
    void Start()
    {
        sf = GetComponent<ScreenFade>();
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sf.StartFadeOut();
            Invoke("LoadNextScene", 2f);
               
        }
    }

    void LoadNextScene()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(i+1);
    }




}
