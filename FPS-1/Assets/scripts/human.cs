using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{
    public Transform freeMode, zoomMode;
    public weapons weapon;
    public Light flashLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0f)
        {
            weapon.Fire();
        }
        if (Input.GetAxis("Fire2") > 0f)
        {
            weapon.transform.parent = zoomMode;
        } else
        {
            weapon.transform.parent = freeMode;
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetAxis("FlashLight") > 0f)
        {
            flashLight.gameObject.SetActive(!flashLight.isActiveAndEnabled);
        }
    }
}
