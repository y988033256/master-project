using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawner : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 10;

    public GameObject holder;

    [SerializeField] TextMeshProUGUI inTimer;
    public List<GameObject> spawnDeliveryItem = new List<GameObject>();

   // public GameObject spawnDeliveryItem;
    public GameObject spawnplace;
    public Vector3 size;
    public Vector3 center;
    public bool itemarrivered;
    public bool doorcanclose = true;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        holder = GameObject.Find("Objectholder");
        size = spawnplace.GetComponent<Renderer>().bounds.size;
        center = spawnplace.GetComponent<Renderer>().bounds.center;
       

    }
    void OnTriggerExit(Collider other)
    {

        //if (other.gameObject.tag == "Player" && other.gameObject.tag == "wooden barrel" && other.gameObject.tag == "wooden box" && other.gameObject.tag == "iron barrel1")
        //{
        //    Debug.Log("mei you dong xi");
        //    doorcanclose = true;
        //}
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("mei you dong xi");
            doorcanclose = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.tag == "Player" && other.gameObject.tag == "wooden barrel" && other.gameObject.tag == "wooden box" && other.gameObject.tag == "iron barrel1")
        //{
        //    Debug.Log("you dong xi");
        //    doorcanclose = false;
        //}
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("you dong xi");
            doorcanclose = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        intimer();       
    }
    void intimer()
    {
        currentTime -= 1 * Time.deltaTime;
        inTimer.text = currentTime.ToString("0") + "s";
        if (currentTime <= 0)
        {
            itemarrivered = true;
            int spawnitem = Random.Range(1, 3);
            for (int i = 0; i < spawnitem; i++)
            {
                Spawnitem();
            }
            currentTime = startingTime;
        }
    }
    void Spawnitem()
    {
        int index = Random.Range(0, spawnDeliveryItem.Count);
        if (spawnDeliveryItem.Count > 0)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 5, Random.Range(-size.z / 2, size.z / 2));
            Instantiate(spawnDeliveryItem[index], pos, Quaternion.identity);
            spawnDeliveryItem[index].GetComponent<pickup>().Objectholder = holder.transform;
        }       
    }
 
}

