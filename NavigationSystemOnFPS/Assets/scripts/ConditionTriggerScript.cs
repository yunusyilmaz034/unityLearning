using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionTriggerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private Text doorBell;

    private void OnTriggerEnter(Collider other)
    {
        doorBell.gameObject.SetActive(true);
        door.GetComponent<doorTrigger>().openSusame();
    }
    private void OnTriggerExit(Collider other)
    {
        door.GetComponent<doorTrigger>().shutDownSusame();
    }
}
