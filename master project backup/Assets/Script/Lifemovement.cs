using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifemovement : MonoBehaviour
{
    GameObject lift;
    public float x;
    public float z;
    public float y;
    public float liftrange = 0.8f;

    // Update is called once per frame
    void Update()
    {
        lift = GameObject.FindWithTag("lift");
        x = lift.transform.position.x;
        z = lift.transform.position.z;
        y = lift.transform.position.y;
       

        if (Input.GetKey(KeyCode.Q))
        {
            if (liftrange < 50.0f)
            {
                y = lift.transform.position.y + 0.2f;
                lift.transform.position = new Vector3(x, y, z);
                liftrange += 0.2f;
            }
           
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (liftrange > 0.8f)
            {
                y = lift.transform.position.y - 0.2f;
                lift.transform.position = new Vector3(x, y, z);
                liftrange -= 0.2f;
            }
           
        }
    }
}
