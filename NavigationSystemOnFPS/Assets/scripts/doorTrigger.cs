using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    

    public void openSusame()
    {  
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Animator>().SetBool("character_nearby", true);
    }
    public void shutDownSusame()
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Animator>().SetBool("character_nearby", false);
    }
}

