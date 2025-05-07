using TMPro;
using UnityEngine;

public class FishCounter : MonoBehaviour
{
    private int fishes = 0;
    public TextMeshPro fishCountText;

    public void FishCaught()
    {
        fishes += 1;
        print("fishes: " + fishes);
        fishCountText.text = fishes.ToString();
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
