using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public Transform Objectholder;
  
    //public float lockPos;
    void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform != null)
            {
                //transform.localScale = transform.localScale / 2;
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().isKinematic = true;
                this.transform.parent = GameObject.Find("Objectholder").transform;
                this.transform.position = Objectholder.position; 
              
            
            }
        }
       
    }
    void OnMouseUp()
    {
       // transform.localScale = transform.localScale * 2;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;   
        this.transform.parent = null;      
    }    
}




//    if (pickObj.GetComponent<Rigidbody>())
//    {
//        Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
//        objRig.useGravity = false;
//        objRig.drag = 10;

//        objRig.transform.parent = holdParent;
//        heldObj = pickObj;
//        Debug.Log("na dong xi");
//    }
//}
//void DropObject()
//{
//    Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
//    heldRig.useGravity = true;
//    heldRig.drag = 1;
//public float pickUpRange = 500;
//public Transform holdParent;
//public float moveforce = 100;
//private GameObject heldObj;

//void Update()
//{
//    if (Input.GetKeyDown(KeyCode.Mouse0)) /*KeyCode.Mouse0*/
//    {

//        if (heldObj == null)
//        {
//            RaycastHit hit;
//            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
//            {
//                Debug.Log("zhe li jin lai le ");
//                PickupObject(hit.transform.gameObject);

//            }
//        }
//        else
//        {
//            DropObject();

//        }
//    }
//    if (heldObj != null)
//    {
//        MoveObject();
//    }
//}
//void MoveObject()
//{
//    if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.5f)
//    {
//        Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
//        heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveforce);
//    }
//}
//void PickupObject(GameObject pickObj)
//{


//    heldObj.transform.parent = null;
//    heldObj = null;

//}