using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        door.GetComponent<doorTrigger>().openSusame();
    }
    private void OnTriggerExit(Collider other)
    {
        door.GetComponent<doorTrigger>().shutDownSusame();
    }
}
