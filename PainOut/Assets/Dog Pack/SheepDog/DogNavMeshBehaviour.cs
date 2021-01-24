using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogNavMeshBehaviour : MonoBehaviour
{
    [SerializeField]
    public Transform goal;
    public GameObject Doggo;
    public RaycastHit Shot;
    public float thrust = 10.0f;
    public Rigidbody rb;
    public float stoppingDistance;
    public float followDistance;
    public float distance;

    void Start(){
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0,thrust,0, ForceMode.Force);

    }

    void FixedUpdate(){
        var playerAgent = GetComponent<NavMeshAgent>();
        playerAgent.destination = goal.position;
        transform.LookAt(goal.transform);
        if (goal != null){
            
            Doggo.GetComponent<Animation>().Play("Lie Down");
       
        }
    }
}

    

