using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamePlayManager : MonoBehaviour
{
    public Image Wheel;
    public GameObject item;
    private GameObject[] duzenek;
    public int rakkam;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < rakkam; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        Wheel.transform.Rotate(new Vector3(0, 0, 1), Time.deltaTime * 10, Space.World);
    }
}
