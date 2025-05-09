using UnityEngine;
using UnityEngine.AI;


public class FishingTest : MonoBehaviour
{
    public FishCounter fishcounter;
    public float Timer = 0f;
    private bool TimerRunning = false;
    public float targetTime = 1f;
    public int stage = 0;
    public float tolerance = 1f;
    public float hookRange = 3f;
    public FishScript currentFish;
    public FishScript caughtFish;
    //public GameObject fish;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentFish == null)
        {
            foreach (var fish in FindObjectsByType<FishScript>(FindObjectsSortMode.None))
            {
                if (Vector3.Distance(fish.transform.position, transform.position) < hookRange)
                {
                    currentFish = fish;
                    currentFish.agent.enabled = false;
                    break;
                }
            }
        }
        else
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

                    string animToPlay = "Pull 0";
                    
                    print("time offset "+timeOffset);
                   
                    Timer = 0;
                    if (timeOffset < tolerance )
                    {
                        stage += 1;
                        print("stage "+stage);
                        if (stage == 1)
                        {
                            targetTime = 0.8f;
                            tolerance = 0.5f;
                            print("tolerance "+tolerance);
                            print("targetTime "+ targetTime);
                        } else if (stage == 2)
                        {
                            targetTime = 0.25f;
                            tolerance = 0.3f;
                        } else if (stage == 3)
                        {
                            print("Fish caught!");
                            animToPlay = "Catch 0";
                            
                            TimerRunning = false;
                            stage = 0;
                            targetTime = 1;
                            tolerance = 0.5f;
                            fishcounter.FishCaught();
                            
                            currentFish.FishThrow();
                            //caughtFish = currentFish;
                            currentFish = null;
                        }
                    }
                    else
                    {
                        TimerRunning = false;
                        stage = 0;
                        targetTime = 1;
                        tolerance = 0.5f;
                       // currentFish.isOnNavMesh = true;

                        currentFish.agent.enabled = true;
                        //currentFish = null;
                        
                        
                    }
                    
                    animator.SetTrigger(animToPlay);
                }
            }
        }
    }
}
