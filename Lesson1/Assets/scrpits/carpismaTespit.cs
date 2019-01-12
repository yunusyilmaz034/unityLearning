using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carpismaTespit : MonoBehaviour
{
    public int puan;
    private List<GameObject> puanObjeleri = new List<GameObject>();
    private void OnCollisionEnter(Collision collision)
    {
        puanObjeleri.Add(GameObject.Find("PositiveObject")); // 3+ 2- olacak
        puanObjeleri.Add(GameObject.Find("PositiveObject"));
        puanObjeleri.Add(GameObject.Find("PositiveObject"));
        puanObjeleri.Add(GameObject.Find("NegativeObject"));
        puanObjeleri.Add(GameObject.Find("NegativeObject"));
        int secimDegiskeni = Random.Range(0, 5);
        float rastgeleXDegiskeni = Random.Range(-5.27f, 6.55f);
        float rastgeleZDegiskeni = Random.Range(-18.67f, - 0.1f);
        GameObject yaratilanObje = (GameObject)Instantiate(puanObjeleri[secimDegiskeni], new Vector3(rastgeleXDegiskeni, 4f, rastgeleZDegiskeni), Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(1, 3, 4);
    }
}
