using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{

    public List<AudioClip> StepSounds;
    public AudioClip jumpSound;
    public AudioClip dashSound;
    public AudioClip deathSound;
    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayStepSounds()
    {
        int random = Random.Range(0,StepSounds.Count);
        audioSource.PlayOneShot(StepSounds[random]);
    }

    public void PlayJumpSounds()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayDashSounds()
    {
        audioSource.PlayOneShot(dashSound);
    }

    public void PlayDeathSounds()
    {
        audioSource.PlayOneShot(deathSound);
    }

}
