using DG.Tweening;
using Unity.Collections;
using UnityEngine;

public class Bone : TimedObject
{
    public void Start()
    {
        secondsOnScreen = GameParameters.BoneSecondsOnScreen;
        base.Start();
        
        transform.rotation = Quaternion.Euler(0f, 0f, -GameParameters.BoneWaggleAngle);
        transform.DORotate(new Vector3(0f,0f,GameParameters.BoneWaggleAngle), 1f/GameParameters.BoneWaggleSpeed)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
