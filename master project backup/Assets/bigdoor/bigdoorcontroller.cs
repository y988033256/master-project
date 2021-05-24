using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigdoorcontroller : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "bigdoor")
        {
            Animator anim = other.GetComponentInChildren<Animator>();
            if (Input.GetKeyDown(KeyCode.E))
                anim.SetTrigger("OpenClose");
        }
    }
}
