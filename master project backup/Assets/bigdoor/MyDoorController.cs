using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnim = null;

    private bool doorOpen = false;

    [SerializeField] private string openAnimationName = "open";
    [SerializeField] private string closeAnimationName = "close";

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;
    public float timer;


    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    public void PlayAnimation()
    {
        if (!doorOpen && !pauseInteraction && GameObject.Find("Spawn point").GetComponent<Spawner>().itemarrivered == true)
        {
            Debug.Log("men kai le ");
            doorAnim.Play(openAnimationName, 0, 0.0f);
            doorOpen = true;
            StartCoroutine(PauseDoorInteraction());
           
        }
        else if (doorOpen && !pauseInteraction)
        {
            Debug.Log("men guan le ");
            doorAnim.Play(closeAnimationName, 0, 0.0f);
            doorOpen = false;
            StartCoroutine(PauseDoorInteraction());
        }
    }
    public void Update()
    {
        if (doorOpen)
        {         
            if (GameObject.Find("Spawn point").GetComponent<Spawner>().currentTime < 5)
            {
                if (GameObject.Find("Spawn point").GetComponent<Spawner>().doorcanclose == true)
                {
                    doorAnim.Play(closeAnimationName, 0, 0.0f);
                    doorOpen = false;
                    StartCoroutine(PauseDoorInteraction());                    
                    GameObject.Find("Spawn point").GetComponent<Spawner>().itemarrivered = false;
                }
               
            }
        }
    }
}
