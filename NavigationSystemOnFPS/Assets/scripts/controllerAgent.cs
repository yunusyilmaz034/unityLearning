using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class controllerAgent : MonoBehaviour
{
    public Camera mainCam;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
     //   agent.destination = destinationTransform.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Direction") > 0) // mouse left click
        {
            RaycastHit rh;
      
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out rh, 100))
            {
                agent.destination = rh.point;
            }
           
        }
        
    }
}
