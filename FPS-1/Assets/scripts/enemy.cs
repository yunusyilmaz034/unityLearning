using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject zombie;
    public GameObject hero;
    public float life;
    public int speed;
    public int limit;
    public float damage;
    public bool isCreated;

    // Start is called before the first frame update
    void Start()
    {
        createZombie();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool createZombie()
    {
        while (!isCreated)
        {
            GameObject z = Instantiate<GameObject>(zombie, new Vector3((hero.transform.position.x + Random.insideUnitSphere.x * 10),
                hero.transform.position.y,
                (hero.transform.position.z + Random.insideUnitSphere.z * 10)), Quaternion.identity);
            limit--;
            if (limit < 0)
            {
                isCreated = false;
                break;
            }
        }
        return false;
    }
}
