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

    private Animator m_zombiAnim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(createZombie());
        createZombie();
        m_zombiAnim = zombie.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator createZombie()
    {
        while (!isCreated)
        {
            GameObject z = Instantiate<GameObject>(zombie, new Vector3((hero.transform.position.x + Random.insideUnitSphere.x * 10),
                hero.transform.position.y,
                (hero.transform.position.z + Random.insideUnitSphere.z * 10)), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            limit--;
            if (limit <= 0)
            {
                isCreated = false;
                break;
            }
        }
    }
    private void LateUpdate()
    {
        if (!m_zombiAnim.GetBool("isFalling"))
        {
            m_zombiAnim.SetBool("isWalk", true);
            zombie.transform.LookAt(hero.transform);
            zombie.transform.position = Vector3.MoveTowards(zombie.transform.position, hero.transform.position, speed * Time.deltaTime);
        }
    }
}
