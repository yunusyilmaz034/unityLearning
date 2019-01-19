using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class carpismaTespit : MonoBehaviour
{
    public int puan;
    public static int toplamPuan; 
    private List<GameObject> puanObjeleri = new List<GameObject>();
    private GameObject puanYazisi;
    private void OnCollisionEnter(Collision collision)
    {
        puanYazisi = GameObject.Find("TotalPuan");
        puanObjeleri.Add(GameObject.Find("PositiveObject")); // 3+ 2- olacak
        puanObjeleri.Add(GameObject.Find("PositiveObject"));
        puanObjeleri.Add(GameObject.Find("PositiveObject"));
        puanObjeleri.Add(GameObject.Find("NegativeObject"));
        puanObjeleri.Add(GameObject.Find("NegativeObject"));
        int secimDegiskeni = Random.Range(0, 5);
        float rastgeleXDegiskeni = Random.Range(-5.27f, 6.55f);
        float rastgeleZDegiskeni = Random.Range(-18.67f, - 0.1f);
        toplamPuan += puan;
        if (toplamPuan >= 30)
        {
            toplamPuan = 0;
            SceneManager.LoadScene(1);
        }
        puanYazisi.GetComponent<Text>().text = "Puan: " + toplamPuan.ToString();
        GameObject yaratilanObje = (GameObject)Instantiate(puanObjeleri[secimDegiskeni], new Vector3(rastgeleXDegiskeni, 4.77f, rastgeleZDegiskeni), Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(1, 3, 4);
    }
}
