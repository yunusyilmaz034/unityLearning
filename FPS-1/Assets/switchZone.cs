using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchZone : MonoBehaviour
{
    public GameObject spotlight;
    private void OnTriggerEnter(Collider other)
    {
        spotlight.GetComponent<Light>().enabled = true;
        ///
        int a = 10;
        int b = 101;

        if (a < b)
        {//true
            Debug.Log(a);
        }
        else
        {//false
            Debug.Log(b);
        }
        int increment = 0;
        for (; ;)
        {
            if (increment > 20)
            {
                break;
            }
            Debug.Log(increment);
            increment++;
        }
        while (increment < 10)
        {
            Debug.Log(increment);
            increment++;
            if (increment == 3)
            {
                continue;
            }
        }
        do
        {
           Debug.Log(increment);
           increment++;
        } while (increment < 10);
        switch (increment)
        {
            case 0:
                Debug.Log("increment en küçük çift sayı oldu");
                break;
            case 1:
                Debug.Log("increment en küçük tek sayı oldu");
                break;
            default:
                Debug.Log("incremet bunların dışında");
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        spotlight.GetComponent<Light>().enabled = false;
    }
}
