using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonAI : MonoBehaviour
{
    private Vector3 startingPoint;
    public float life;
    public int scoreModifier = 100;
    public bool dead = false;
    private Animation anim;


    void Start()
    {
        anim = GetComponent<Animation>();
        startingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
