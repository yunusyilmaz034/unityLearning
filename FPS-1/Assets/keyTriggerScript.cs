using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyTriggerScript : MonoBehaviour
{
    public Text TriggerText;
    // Start is called before the first frame updat
    private void OnTriggerStay(Collider other)
    {
        TriggerText.enabled = false;
        
        if (Input.GetAxis("TriggerLight") > 0f)
        {
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        TriggerText.enabled = false;
    }
}
