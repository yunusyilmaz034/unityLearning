using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyTriggerScript : MonoBehaviour
{
    public Text TriggerText;
    public GameObject StreetLight;
    // Start is called before the first frame updat
    private void OnTriggerStay(Collider other)
    {
        TriggerText.text = "Işığı yakmak için 'E' basınız";
        if (Input.GetAxis("TriggerLight") > 0f)
        {
            StreetLight.SetActive(!StreetLight.activeSelf); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        TriggerText.text = "";
    }
}
