using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kayitKontrol : MonoBehaviour
{
    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("ToplamPuan"))
        {
            PlayerPrefs.SetInt("ToplamPuan", carpismaTespit.toplamPuan);
        } else
        {
            int highPuan = PlayerPrefs.GetInt("ToplamPuan");
            if (highPuan < carpismaTespit.toplamPuan)
            {
                PlayerPrefs.SetInt("ToplamPuan", carpismaTespit.toplamPuan);
            }
        }
        highScore.text = "High Score: " + PlayerPrefs.GetInt("ToplamPuan");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
