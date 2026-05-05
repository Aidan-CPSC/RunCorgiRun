using UnityEngine;

public class PoopPlacer : MonoBehaviour
{
    public GameObject PoopPrefab;
    public Sounds Sounds;
    
    public void Place(Vector3 corgiPosition)
    {
        Instantiate(PoopPrefab, corgiPosition, Quaternion.identity);
        Sounds.PlayPoopSound();
    }
}
