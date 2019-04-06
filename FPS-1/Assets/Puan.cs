using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puan : MonoBehaviour
{
    // Start is called before the first frame update
    public int puan;
    private GameObject particle;
    private BoxCollider m_boxCollider;

    private void OnBecameVisible()
    {
        particle = transform.Find("Particle").gameObject;
        m_boxCollider = gameObject.GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_boxCollider.enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            particle.SetActive(true);
            GameManager.TotalPuan += puan;
            Destroy(gameObject, 2.5f);
        }
    }

}
