using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    float throwForce = 600;
    Vector3 objectPosition;
    float distance;

    public bool canHold = true;
    public GameObject item;
    public GameObject temporaryParent;
    public bool isHolding = false;

    
    void Update()
    {

        distance = Vector3.Distance(item.transform.position, temporaryParent.transform.position);
        if (distance >= 2f){
            isHolding = false;
        }

        if (isHolding == true){
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(temporaryParent.transform);

            if (Input.GetButtonDown("Fire2")){
                item.GetComponent<Rigidbody>().AddForce(temporaryParent.transform.forward * throwForce);
                isHolding = false;
            }
        } else {
            objectPosition = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPosition;
        }
    }

    void OnMouseDown(){
        if (distance <= 2f){
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }
    }

    void OnMouseUp(){
        isHolding = false;
    }
}
