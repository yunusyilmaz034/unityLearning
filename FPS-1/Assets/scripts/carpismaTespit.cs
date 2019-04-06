using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carpismaTespit : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        explosion.SetActive(true);
        Debug.Log(other.gameObject.name);
    }
}
