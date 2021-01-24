using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballPickUp : MonoBehaviour
{
    
    public Transform theDestination;

    
    void OnMouseDown(){
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
         GetComponent<Rigidbody>().freezeRotation = true; 
        this.transform.position = theDestination.position;
        this.transform.parent = GameObject.Find("Destination").transform;
        if (Input.GetButtonDown("Fire2")){

        }
    }

    void OnMouseUp(){
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<SphereCollider>().enabled = true;
         
    }
}
