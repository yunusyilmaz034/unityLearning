using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionTriggerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private GameObject doorBell;

    private bool isTrigger = false;

    private void Update()
    {
        if (isTrigger)
        {
            if (Input.GetAxis("Door Bell") > 0)
            {
                Debug.Log("kapı açıldı");
                isTrigger = false;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        isTrigger = true;
        doorBell.SetActive(true);
      //  door.GetComponent<doorTrigger>().openSusame();
    }
    
    private void OnTriggerExit(Collider other)
    {
        isTrigger = false;
        doorBell.SetActive(false);
        //door.GetComponent<doorTrigger>().shutDownSusame();
    }
}
