using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int TotalPuan = 0;
    public Text puanYazisi;

    void Update()
    {
        puanYazisi.text = string.Format("Puan: {0}", TotalPuan.ToString());
        Debug.Log("Puan: " + TotalPuan.ToString());
    }
}
