using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePlay : MonoBehaviour
{
    public GameObject zombie;
    public GameObject dummyPosition;
    public static int limit = 10;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate<GameObject>(zombie, dummyPosition.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
