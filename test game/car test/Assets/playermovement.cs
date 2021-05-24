using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float movespeed = 40f;
  

    Vector3 velocity;

  
    void Update()
    {
      
        if ( velocity.y < 0)
        {
            velocity.y = -2f;
        } 


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

}



  