using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnterVehicle : MonoBehaviour
{
    public bool inVehicle = false;
    CarController vehicleScript;
    public GameObject guiObj;
    GameObject Player;


    void Start()
    {
        vehicleScript = GetComponent<CarController>();
        Player = GameObject.FindWithTag("Player");
        guiObj.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
           
            guiObj.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                guiObj.SetActive(false);
                Player.transform.parent = gameObject.transform;
                vehicleScript.enabled = true;
                Player.SetActive(false);
                inVehicle = true;
                Debug.Log("shang che");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiObj.SetActive(false);
        }
    }
    void Update()
    {
        if (inVehicle == true && Input.GetKey(KeyCode.F))
        {
            vehicleScript.enabled = false;
            Player.SetActive(true);
            Player.transform.parent = null;
            inVehicle = false;
        }
    }
}