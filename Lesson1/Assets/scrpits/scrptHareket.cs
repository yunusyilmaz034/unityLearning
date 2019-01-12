using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrptHareket : MonoBehaviour
{
    public int speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(string.Format("x : {0}", gameObject.transform.position.x.ToString()));
        Debug.Log(string.Format("y : {0}", gameObject.transform.position.y.ToString()));
        Debug.Log(string.Format("z : {0}", gameObject.transform.position.z.ToString()));

    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKey(KeyCode.A)) {

            gameObject.transform.position = new Vector3((gameObject.transform.position.x - speed) * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }

       
       /*
        if(Input.GetAxis("Horizontal") < 0.0) //left
        {
            gameObject.transform.position = new Vector3((gameObject.transform.position.x - speed) * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
             
        } else //rigth
        {
            gameObject.transform.position = new Vector3((gameObject.transform.position.x + speed) * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (Input.GetAxis("Vertical") < 0.0) // down
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, (gameObject.transform.position.z - speed) * Time.deltaTime);
        } else //up
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, (gameObject.transform.position.z + speed) * Time.deltaTime);
        }
        */
    }
}
