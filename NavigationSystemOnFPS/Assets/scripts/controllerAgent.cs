using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class controllerAgent : MonoBehaviour
{
    public GameObject destinationTransform;
    private NavMeshAgent agent;

    public bool isWalk = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.destination = destinationTransform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
