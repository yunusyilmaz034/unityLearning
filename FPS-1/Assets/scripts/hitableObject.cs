using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitableObject : MonoBehaviour
{
    public float life;
    public AudioClip audioEffect;
    public Material damageMaterial;
    public GameObject smoke, fire, explosion;
    private bool isExp;
    // Start is called before the first frame update
    void Start()
    {
        isExp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0 && !isExp)
        {
            explosion.SetActive(true);
            fire.SetActive(true);
            smoke.SetActive(true);
            AudioSource.PlayClipAtPoint(audioEffect, transform.position);
            MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
            mr.material = damageMaterial;
            isExp = true;  
        }
    }
    public void Hitted(float power)
    {
        life -= power;
        Debug.Log("life: " + life);
    }
}
