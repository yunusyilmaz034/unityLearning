using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionTriggerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private GameObject doorBell;
    [SerializeField]
    private Light doorLight;
    [SerializeField]
    private GameObject hingeDoor;

    private bool isTrigger = false;

    private void Start()
    {
        doorBell.SetActive(false);
    }

    private void Update()
    {
        if (isTrigger)
        {
            if (Input.GetAxis("Door Bell") > 0) //E bastın mı
            {
                doorLight.color = Color.green;
                hingeDoor.GetComponent<Animator>().SetBool("character_nearby", true);
                isTrigger = false;

            } else
            {   
                return;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.name.Equals("FPSController"))
        {
            return;
        }
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
