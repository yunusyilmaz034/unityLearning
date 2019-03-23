using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csRifle : weapons
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Reload") > 0f)
        {
            if (currentBullets <= 0)
            {
                maxBullets = 30;
                currentBullets = 30;
            }
        }
    }
    public override bool Fire()
    {
        if (base.Fire())
        {
            Debug.DrawRay(transform.position, transform.forward * range, Color.green);
            Ray r = new Ray(transform.position, transform.forward * range);
            RaycastHit rh;
            if (Physics.Raycast(r, out rh))
            {
                Debug.Log(rh.transform.gameObject.name);
                hitableObject h = rh.transform.GetComponent<hitableObject>();                
                if (h != null)
                {
                    h.Hitted(damage);
                }
                enemy e = rh.transform.GetComponent<enemy>();
                if (e != null)
                {
                    e.Hitted(damage);
                }
            }
            return true;
        }
        return false;
    }

}
