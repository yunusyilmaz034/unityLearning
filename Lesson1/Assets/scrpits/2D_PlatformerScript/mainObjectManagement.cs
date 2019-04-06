using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainObjectManagement : MonoBehaviour
{
    public bool isRotate = true;
    public int upMultiplier = 4000;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer == 9)
        {
            isRotate = true;
        }
        if (isRotate)
        {
            transform.Rotate(0, 0, 5f);
        }
    }
    public void tiklaFirlat()
    {
       isRotate = false;
        GameObject gm = Instantiate<GameObject>(gameObject, transform.position, transform.rotation, transform.parent);
        gm.name = "top";
        rb.AddForce(transform.up * upMultiplier, ForceMode2D.Impulse);
        gameObject.layer = 10;
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.isKinematic = true;
        rb.Sleep();
        Debug.Log("herhangi bir obje çarptı");
        if (collision.gameObject.name == "top")
        {
            Debug.Log("top objesine çarpıldı");
            gameManagment.score -= 10;
            return;
        }
        gameManagment.score += 10;
    }
}
