using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons : MonoBehaviour
{
    public float range, damage, fireRate, fireTime;
    public AudioClip sound;
    protected int m_currentBullets = 30;
    public Light muzzleLight;
    public int maxBullets;
    public float clipRate;
    private float muzzleRate;

    //property
    public int currentBullets
    {
        get
        {
            return m_currentBullets;
        }
        set
        {
            this.m_currentBullets = value;
        }
    }
    //currentBullets = 10; set bölümü çalışır
    //int sum = currentBullets; get bölümü çalışır
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (muzzleRate > 0)
        {
            muzzleRate -= Time.deltaTime;
        } else
        {
            muzzleLight.intensity = 0;
        }
        Debug.Log("akış1");
    }
    public virtual bool Fire()
    {
        if (Time.time > fireTime + fireRate && currentBullets > 0)
        {
            currentBullets--;
            fireTime = Time.time;
            AudioSource.PlayClipAtPoint(sound, transform.position);
            muzzleLight.intensity = 4;
            muzzleRate = 0.1f;
            return true;
        }
        return false;
    }
}
