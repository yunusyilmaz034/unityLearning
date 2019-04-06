using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class carpisma : MonoBehaviour
{
    public int puan;
    private GameObject puanYazisi;
    public static int toplamPuan;
    private List<GameObject> puanObjeleri = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {
        puanObjeleri.Add(GameObject.Find("PositiveObject"));
        puanObjeleri.Add(GameObject.Find("PositiveObject"));
        puanObjeleri.Add(GameObject.Find("PositiveObject"));
        puanObjeleri.Add(GameObject.Find("PositiveObject"));
        puanObjeleri.Add(GameObject.Find("NegativeObject"));
        puanYazisi = GameObject.Find("TotalPuan");
    }
    private void OnCollisionEnter(Collision collision)
    {
        toplamPuan += puan;
        if (toplamPuan >= 30)
        {
            SceneManager.LoadScene(2);
        }
        puanYazisi.GetComponent<Text>().text = "Toplam Puan: " + toplamPuan.ToString(); //string.Format("Toplam Puan: {0}", toplamPuan.ToString());
        int rIndex = Random.Range(1, 5);
        float xDegiskeni = Random.Range(-1.4f, 15.2f);
        float zDegiskeni = Random.Range(-39.46f, -27.15f);
        GameObject g = Instantiate<GameObject>(puanObjeleri[rIndex], new Vector3(xDegiskeni, 14.73f, zDegiskeni), Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(10, 10, 10);
    }
}
