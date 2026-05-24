using UnityEngine;
using UnityEngine.Playables;

public class TimelineSkipper : MonoBehaviour
{
    public PlayableDirector[] timelines; // Inspector’dan 4 Timeline’ı sürükle
    public float[] skipTimes;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            for (int i = 0; i < timelines.Length; i++)
            {
                if (timelines[i].state == PlayState.Playing)
                {
                    // Aktif Timeline bulundu → skip uygula
                    timelines[i].time = skipTimes[i]; // direkt sona atlat
                    timelines[i].Evaluate();
                    
                }    
            }

        }
    }
}
