using UnityEngine;

public class TimelineSignal : MonoBehaviour
{
    public static bool freezePlayer = false;

    public void FreezePlayer()
    {
        freezePlayer = true;
    }

    public void UnFreezePlayer()
    {
        freezePlayer = false;
    }
}
