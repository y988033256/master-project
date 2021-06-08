using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class timer : MonoBehaviour
{
    float currentTime = 0;
    float startingTime = 60;
    
    [SerializeField] TextMeshProUGUI inTimer; 
    [SerializeField] TextMeshProUGUI outTimer;    
    
    void Start()
    {
        currentTime = startingTime;
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
            currentTime = 0;
        }
    }
}
