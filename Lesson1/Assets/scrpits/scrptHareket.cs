using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrptHareket : MonoBehaviour
{
    public int speed = 0;
    // Start is called before the first frame update
    Rigidbody rBody;
    void Start()
    {
        Debug.Log(string.Format("x : {0}", gameObject.transform.position.x.ToString()));
        Debug.Log(string.Format("y : {0}", gameObject.transform.position.y.ToString()));
        Debug.Log(string.Format("z : {0}", gameObject.transform.position.z.ToString()));
        Debug.Log(string.Format("speed: {0}", speed));
        rBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rBody.AddForce(0, 0, speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rBody.AddForce(0, 0, -speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rBody.AddForce(-speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rBody.AddForce(speed, 0, 0);
        }
        else
        {
            Debug.Log("Herhangi bir tuşa basıldı.");
        }
    }
}