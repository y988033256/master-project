using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnterVehicle : MonoBehaviour
{
    public bool inVehicle = false;
    public  bool TriggerRdy = true;
    CarController vehicleScript;
    public GameObject PressF;
    GameObject Player;
    GameObject vehicalecamera;
    public GameObject seat;


    public float timerCountDown = 1.5f;

    void Start()
    {
        vehicleScript = GetComponent<CarController>();
        Player = GameObject.Find("Player");
        vehicalecamera = GameObject.Find("vehicalecamera");
        PressF.SetActive(false);
        //PressG.SetActive(false);
        vehicalecamera.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player" && inVehicle == false && TriggerRdy == true)
        {
            PressF.SetActive(true);
            Debug.Log("jian ce daole ");
            if (Input.GetKey(KeyCode.F))
            {
                Player.SetActive(false);
                PressF.SetActive(false);
                //PressG.SetActive(true);
                Player.transform.parent = seat.transform;
                vehicleScript.enabled = true;          
                inVehicle = true;
                vehicalecamera.SetActive(true);
                TriggerRdy = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PressF.SetActive(false);
        }
    }
    void Update()
    {
        if (TriggerRdy == true)
        {

            if (timerCountDown > 0)
            {
                timerCountDown -= Time.deltaTime;
            }
            else             
            {
                timerCountDown = 1.5f;
                TriggerRdy = false;
               // inVehicle = false;
            }
        }
        if (TriggerRdy == false)
        {
            if (timerCountDown > 0)
            {
                timerCountDown -= Time.deltaTime;
            }
            else
            {
                timerCountDown = 1.5f;
                TriggerRdy = true;              
            }
        }
        if (inVehicle == true)
        {
            PressF.SetActive(true);
        }

        if (inVehicle == true && Input.GetKey(KeyCode.F) && TriggerRdy == false)
        {
            PressF.SetActive(false);
            vehicleScript.enabled = false;
            vehicalecamera.SetActive(false);
            Player.SetActive(true);
            Player.transform.parent = null;
            inVehicle = false;
          
        }
    }

}