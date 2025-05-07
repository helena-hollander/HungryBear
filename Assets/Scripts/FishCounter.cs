using UnityEngine;

public class FishCounter : MonoBehaviour
{
    private int fishes = 0;

    public void FishCaught()
    {
        fishes++;
        print("fishes: " + fishes);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
