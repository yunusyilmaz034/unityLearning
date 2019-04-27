using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamePlayManager : MonoBehaviour
{
    public Image Wheel;
    public GameObject item;
    public GameObject[] duzenek;
    public GameObject[] kuyruk;
    public Sprite[] spr;
    private int[] generateNum = new int[8];
    //private int[] generateNum;
    private System.Random r = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        GenerateNumbers();
        //GenerateNumbers2();
        controlForWheel();
        for (int i = 0; i < duzenek.Length; i++)
        {
            duzenek[i].GetComponent<Image>().sprite = spr[generateNum[i]];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Wheel.transform.Rotate(new Vector3(0, 0, 1), Time.deltaTime * 10, Space.World);
    }
    void GenerateNumbers() //random
    {
        for (int i = 0; i < 8; i++)
        {
            generateNum[i] = r.Next(0, 10);
        }
    }
    void GenerateNumbers2()
    {
        if (generateNum == null)
        {
            generateNum = new int[]{0};
        }
        bool flag = false;

        int createNumber = r.Next(0, 10);
        for (int i = 0; i < generateNum.Length; i++)
        {
            if (createNumber == generateNum[i])
            {
                flag = true;
            }
        }
        if (flag && generateNum.Length > 7)
        {
            GenerateNumbers2();
            generateNum = new int[] { createNumber };
        }

    }
    void controlForWheel()
    {
        for (int k = 0; k < generateNum.Length; k++)
        {
            for (int i = k + 1; i < generateNum.Length; i++)
            {
                if (generateNum[k] == generateNum[i])
                {
                    generateNum[i] = randomNumberForGenerateNumArray();
                }
            }
        }
    }
    int randomNumberForGenerateNumArray()
    {
        
        int createNumber = r.Next(0, 10);
        for (int i = 0; i < generateNum.Length; i++)
        {
            if (createNumber == generateNum[i])
            {
                createNumber = r.Next(0, 10);
                i = -1;
            }
        }
        return createNumber;
    }
 

}
