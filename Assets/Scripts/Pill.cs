using DG.Tweening;
using UnityEngine;

public class Pill : TimedObject
{
    public void Start()
    {
        secondsOnScreen = GameParameters.PillSecondsOnScreen;
        base.Start();
        
        float duration = 360f/GameParameters.PillSpinDegreesPerSecond;
        transform.DORotate(new Vector3(0f, 0f, 360f), duration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);;
    }
}
