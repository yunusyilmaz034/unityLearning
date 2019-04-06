using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManagment : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 0;
    public Text scoreText;
    public static int highScore = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Puan: " + score;
    }
}
