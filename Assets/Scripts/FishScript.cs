using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3; //important

//if you use this code you are contractually obligated to like the YT video
public class FishScript : MonoBehaviour //don't forget to change the script name if you haven't
{
    public NavMeshAgent agent;
    public float range; //radius of sphere
    public FishingTest fishCatched;
    private Rigidbody rb;

    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
{
    // Kun hvis vi ikke venter på ny path OG vi er tæt nok på målet
    if (agent.enabled)
    {
   

    if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
    {
        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }
        }
    }
    }
}

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        { 
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    public void FishThrow()
    {


    rb = gameObject.GetComponent<Rigidbody>();
    rb.AddForce(Vector3.up *2000);
    rb.AddForce(Vector3.right * 1.5f);


    }


}