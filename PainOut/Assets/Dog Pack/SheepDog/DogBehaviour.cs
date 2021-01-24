using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviour : MonoBehaviour
{
    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedDistance = 10;
    public GameObject Doggo;
    public float FollowSpeed;
    public RaycastHit Shot;
    public float thrust = 10.0f;
    public Rigidbody rb;

    

    void Start(){
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0,thrust,0, ForceMode.Force);

    }
    
    
    void FixedUpdate()
    {
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot)){
            TargetDistance = Shot.distance;
            if (TargetDistance <= AllowedDistance/2  && TargetDistance >= 2){
                FollowSpeed = 0.03f;
                Doggo.GetComponent<Animation>().Play("Walk");
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, FollowSpeed);
                
            } else if (TargetDistance >= AllowedDistance/2){
                FollowSpeed = 0.05f;
                Doggo.GetComponent<Animation>().Play("Run");
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, FollowSpeed);

            } else {
                FollowSpeed = 0;
                
                Doggo.GetComponent<Animation>().Play("Lie Down");
                //DogRest();
            }
        }
    }

    IEnumerator DogRest(){
        
        yield return new WaitForSeconds(1f);
        Doggo.GetComponent<Animation>().Play("lopp Sleep");
    }
}
