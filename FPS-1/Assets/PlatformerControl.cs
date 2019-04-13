using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerControl : MonoBehaviour
{
    private Rigidbody cha_rb;
    private Animation cha_anim;
    private Camera cam;
    public GameObject dummyCamZoomPosition;
    public static bool jumpable = true;
    public int speed = 10;
    public int jumpHeight = 9;
    private float jumpCamPosition = 11f;
    // Start is called before the first frame update
    void Start()
    {
        cha_rb = GetComponent<Rigidbody>();
        cha_anim = GetComponent<Animation>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        cha_rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, cha_rb.velocity.y, 0);
        if (Input.GetAxis("Horizontal") != 0)
        {
            cha_anim.Play("Walk");
            cha_anim["Walk"].speed = 1.7f;
        }
        if (Input.GetAxis("Horizontal") < 0) 
        {
            transform.localEulerAngles = new Vector3(0, -90, 0);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }

        if (Input.GetAxis("Vertical") > 0f) 
        {
            Jump();
        }
    }
    private void Jump()
    {
        if (jumpable)
        {
            jumpable = false;
            cha_rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
          
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("çapışılan nesne: " + collision.gameObject.name.ToString());
       jumpable = true;
      
        /* camera zoom mode için eklendi
        if (!collision.gameObject.tag.Equals("mainPlatform"))
        {
            cam.transform.position = new Vector3(transform.position.x + 3.5f, 781.519f + 2.5f, dummyCamZoomPosition.transform.position.z);
        } else
        {
            cam.transform.position = new Vector3(transform.position.x + 3.5f, 781.519f + 2.5f, transform.position.z - jumpCamPosition);
        }
        */
    }
   
    private void LateUpdate()
    {
        cam.transform.position = new Vector3(transform.position.x + 3.5f, 781.519f + 2.5f, transform.position.z - jumpCamPosition);
    }
   
}
