using System.Collections;
using UnityEngine;

public class BeerPlacer : MonoBehaviour
{
    public GameObject BeerPrefab;
    void Update()
    {
        StartCoroutine(CountdownUntilCreation());
    }

    IEnumerator CountdownUntilCreation()
    {
        yield return new WaitForSeconds(GameParameters.BeerSecondsUntilCreation);
        Place();
    }

    private void Place()
    {
        Instantiate(BeerPrefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}
