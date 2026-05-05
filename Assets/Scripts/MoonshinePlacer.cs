using UnityEngine;

public class MoonshinePlacer : TimedObjectPlacer
{
    public Sounds Sounds;
    
    public void Start()
    {
        minimumSecondsToWait = GameParameters.MoonshineMinimumSecondsToWait;
        maximumSecondsToWait = GameParameters.MoonshineMaximumSecondsToWait;
    }

    public override void Place()
    {
        Instantiate(Prefab, SpawnTools.RandomTopOfScreenLocationWorldSpace(), Quaternion.identity);
        Sounds.PlayFallingSound();
    }
}
