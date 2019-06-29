using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDoorTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private GameObject infoPanel;
    [SerializeField]
    private bool autoClosed = true;

    private bool isTriggerPanel = false;

    private void Update()
    {
        if (isTriggerPanel)
        {
            if (Input.GetAxis("Door Bell") > 0) //E bastın mı
            {
                if (door.GetComponent<Animator>().GetBool("character_nearby") && !autoClosed)
                {
                    door.GetComponent<doorTrigger>().shutDownSusame();
                }
                else if (!door.GetComponent<Animator>().GetBool("character_nearby"))
                {
                    door.GetComponent<doorTrigger>().openSusame();
                    
                }
                isTriggerPanel = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isTriggerPanel = true;
        infoPanel.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        isTriggerPanel = false;
        infoPanel.SetActive(false);
        if (autoClosed)
        {
            door.GetComponent<doorTrigger>().shutDownSusame();
        }
    }
}
