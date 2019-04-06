using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    Rigidbody r;//global scope
    public int speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        r = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0f) //left
        {
            r.AddForce(-speed, 0, 0, ForceMode.Force);
        }
        else if (Input.GetAxis("Horizontal") > 0f) //right 
        {
            r.AddForce(speed, 0, 0, ForceMode.Force);
        }
        if (Input.GetAxis("Vertical") < 0f) //down 
        {
            r.AddForce(0, 0, -speed);
        } else if (Input.GetAxis("Vertical") > 0f) //up 
        {
            r.AddForce(0, 0, speed);
        }

    }
}
