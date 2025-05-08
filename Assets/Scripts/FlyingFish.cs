using UnityEngine;

public class FlyingFish : MonoBehaviour
{
    public Vector3 hookPos;
    public FishScript fishPos;
   
   
    void Update()
    {
        foreach (var fish in FindObjectsByType<FishScript>(FindObjectsSortMode.None))
        {
            
        }
    }
}
