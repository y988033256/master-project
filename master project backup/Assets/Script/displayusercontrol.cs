using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayusercontrol : MonoBehaviour
{
    public GameObject pressY;
    public GameObject showUI;
    public bool UIopen;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(pressy()); 
    }

    public IEnumerator pressy()
    {
        pressY.SetActive(true);
        yield return new WaitForSeconds(5);
        pressY.SetActive(false);
    }
   public void closeUI()
    {
        showUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            showUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            // UIopen = true;
        }
    }
}
