using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineSkipper : MonoBehaviour
{
    public PlayableDirector[] timelines; // Inspector’dan 4 Timeline’ı sürükle
    public float[] skipTimes;
    public bool[] timelineSkipped;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            for (int i = 0; i < timelines.Length; i++)
            {
                if (timelines[i].state == PlayState.Playing)
                {
                    if(!timelineSkipped[i])
                    {
                        timelineSkipped[i] = true;                        
                        timelines[i].time = skipTimes[i]; // direkt sona atlat
                        timelines[i].Evaluate();    
                    }
                    
                    
                }    
            }

        }
    }
}
