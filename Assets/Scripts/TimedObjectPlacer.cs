using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject Prefab;
    private bool isOkToCreate = false;
    private bool isActive = false;
    private Coroutine countdownCoroutine;
    
    public float minimumSecondsToWait;
    public float maximumSecondsToWait;
    
    void Update()
    {
        if (!isActive) return;
        if (isOkToCreate)
        {
            countdownCoroutine = StartCoroutine(CountdownUntilCreation());
        }
    }

    public void StartPlacing()
    {
        isActive = true;
        isOkToCreate = true;
    }

    public void StopPlacing()
    {
        isActive = false;
        isOkToCreate = false;

        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        CleanupPlacedObjects();
    }

    private void CleanupPlacedObjects()
    {
        List<GameObject> placedObjects = GameObject.FindGameObjectsWithTag(Prefab.tag).ToList();

        for (int i = 0; i < placedObjects.Count; i++)
        {
            Destroy(placedObjects[i]);
        }
    }

    IEnumerator CountdownUntilCreation()
    {
        isOkToCreate = false;

        float secondsToWait = Random.Range(minimumSecondsToWait, maximumSecondsToWait);
        yield return new WaitForSeconds(secondsToWait);
        Place();
        
        isOkToCreate = true;
    }

    public virtual void Place()
    {
        Instantiate(Prefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}
