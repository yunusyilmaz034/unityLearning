using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
   // public GameObject zombie;
    private GameObject hero;
    public float life;
    public float speed;
    public float damage = 10;
    public bool isCreated = false;

    private Animator m_zombiAnim;
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.Find("Hero");
        StartCoroutine(createZombie());
        createZombie();
        m_zombiAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator createZombie()
    {
        while (!isCreated)
        {
            if (gamePlay.limit <= 0)
            {
                isCreated = true;
                break;
            }
            GameObject z = Instantiate<GameObject>(gameObject, new Vector3((hero.transform.position.x + Random.insideUnitSphere.x * 10),
                hero.transform.position.y,
                (hero.transform.position.z + Random.insideUnitSphere.z * 10)), Quaternion.identity);
            gamePlay.limit--;
            yield return new WaitForSeconds(1f);
        }
    }
    private void LateUpdate()
    {
        if (!m_zombiAnim.GetBool("isFalling"))
        {
            m_zombiAnim.SetBool("isWalk", true);
            gameObject.transform.LookAt(hero.transform);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, hero.transform.position, speed * Time.deltaTime);
        }
    }
    public void Hitted(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            m_zombiAnim.SetBool("isFalling", true);
            StartCoroutine(zombiKill());
        }
    }
    public IEnumerator zombiKill()
    {
        yield return new WaitForSeconds(2f);
        GameObject.Destroy(gameObject);
    }
}
