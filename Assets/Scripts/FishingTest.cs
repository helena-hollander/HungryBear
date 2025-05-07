using UnityEngine;

public class FishingTest : MonoBehaviour
{

    public float Timer = 0f;
    private bool TimerRunning = false;
    public float targetTime = 1f;
    public float targetTime2 = 0.5f;
    public float targetTime3 = 0.25f;
    private int stage = 0;
    public float tolerance = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!TimerRunning)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("Fishing");
                TimerRunning = true;

            }
        }
        else
        {
                Timer += Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    float timeOffset = Mathf.Abs(targetTime - Timer);
                    
                    print("time offset "+timeOffset);
                   
                    Timer = 0;
                    if (timeOffset < tolerance )
                    {
                        stage += 1;
                        print("stage "+stage);
                    }
                    else
                    {
                        TimerRunning = false;
                        stage = 0;
                    }
                }
            }
    }
}
